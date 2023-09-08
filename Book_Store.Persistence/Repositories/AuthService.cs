using Book_Store.Application.Constance;
using Book_Store.Application.Contracts.Identity;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.Models.Identity;
using Book_Store.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Book_Store.Persistence.Repositories
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IRefreshTokenRepository _refreshTokenRepository;


        public AuthService(UserManager<ApplicationUser> userManager, IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager, IRefreshTokenRepository refreshTokenRepository)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _refreshTokenRepository = refreshTokenRepository;
        }

        #region Register

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.UserName);
            if (existingUser != null)
            {
                throw new Exception($"نام کاربری {request.UserName} قبلا استفاده شده است.");
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailConfirmed = true,
                UserName = request.UserName,
            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Employee");



                    return new RegistrationResponse() { UserId = user.Id };
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }
            else
            {
                throw new Exception($"ایمیل {request.Email} قبلا استفاده شده است.");
            }

        }
        #endregion

        public async Task<AuthResponse> Login(AuthRequset requset)
        {
            var user = await _userManager.FindByEmailAsync(requset.Email);
            if (user is null)
                throw new Exception("کاربر یافت نشد.");

            var result = await _signInManager.PasswordSignInAsync(user.UserName, requset.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new Exception("عملیات با شکست روبرو شد.");
            }

            var jwtTokenId = Guid.NewGuid().ToString();

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user, jwtTokenId);
            var refreshToken = await CreateNewRefreshToken(user.Id, jwtTokenId);
            AuthResponse response = new AuthResponse()
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName,
                RefreshToken = refreshToken
            };

            return response;

        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user, string jwtTokenId)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,jwtTokenId),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(CustomClaimTypes.Uid,user.Id.ToString()),
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricseurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signInCredentials = new SigningCredentials(symmetricseurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims = claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signInCredentials
                );

            return jwtSecurityToken;
        }

        public async Task<AuthResponse> RefreshAccessToken(AuthResponse Token)
        {
            //Find an existing refresh token
            var existingRefreshToken = await _refreshTokenRepository.GetRefreshToken(Token.RefreshToken);
            if (existingRefreshToken is null)
                return new AuthResponse();

            //compare data from existing refresh and access tiken provider and if there is any missmatch then consider it
            var accessTokenData = GetAccessTokenData(Token.Token);
            if (!accessTokenData.isSuccessful || accessTokenData.userId != existingRefreshToken.UserId ||
                accessTokenData.tokenId != existingRefreshToken.JwtTokenId)
            {
                existingRefreshToken.IsValid = false;
                await _refreshTokenRepository.Update(existingRefreshToken);
                return new AuthResponse();
            }

            //when someone tries to use not valid refresh token ,  fraud possible
            if (!existingRefreshToken.IsValid)
            {
                var chainRecords = await _refreshTokenRepository.GetUserRefreshTokens(existingRefreshToken.UserId, existingRefreshToken.JwtTokenId);

                chainRecords.ForEach(x => x.IsValid = false);
                
                await _refreshTokenRepository.UpdateRange(chainRecords);
                return new AuthResponse();
            }

            //If just expired then mark as invalid and return empty
            if (existingRefreshToken.ExpireAt < DateTime.UtcNow)
            {
                existingRefreshToken.IsValid = false;
                await _refreshTokenRepository.Update(existingRefreshToken);
                return new AuthResponse();
            }


            //replace old refresh wiht a new one with update expire date  
            var newRefrashToken = await CreateNewRefreshToken(existingRefreshToken.UserId, existingRefreshToken.JwtTokenId);

            //revoke existing refresh token
            existingRefreshToken.IsValid = false;
            await _refreshTokenRepository.Update(existingRefreshToken);

            //generate new access token
            var applicationUser = await _userManager.FindByIdAsync(existingRefreshToken.UserId.ToString());
            if (applicationUser is null)
                return new AuthResponse();

            var newAccessToken = await GenerateToken(applicationUser, existingRefreshToken.JwtTokenId);

            return new AuthResponse
            {
                Id = applicationUser.Id,
                Email = applicationUser.Email,
                UserName = applicationUser.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefrashToken
            };

        }


        private async Task<string> CreateNewRefreshToken(int userId, string tokenId)
        {
            RefreshToken refreshToken = new()
            {
                IsValid = true,
                UserId = userId,
                JwtTokenId = tokenId,
                ExpireAt = DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                Refresh_Token = Guid.NewGuid() + "-" + Guid.NewGuid(),
            };

            await _refreshTokenRepository.Add(refreshToken);

            return refreshToken.Refresh_Token;

        }

        private (bool isSuccessful, int? userId, string tokenId) GetAccessTokenData(string accessToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwt = tokenHandler.ReadJwtToken(accessToken);
                var jwtTokenId = jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Jti).Value;
                var userId = jwt.Claims.FirstOrDefault(u => u.Type == CustomClaimTypes.Uid).Value;
                return (true, int.Parse(userId), jwtTokenId);
            }
            catch
            {
                return (false, null, null);
            }
        }
    }
}
