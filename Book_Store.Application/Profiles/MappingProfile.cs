using AutoMapper;
using Book_Store.Application.DTOs.Author;
using Book_Store.Application.DTOs.Book;
using Book_Store.Application.DTOs.BookImage;
using Book_Store.Application.DTOs.Category;
using Book_Store.Application.DTOs.Comment;
using Book_Store.Application.DTOs.Publisher;
using Book_Store.Application.DTOs.Role;
using Book_Store.Application.DTOs.Translator;
using Book_Store.Application.DTOs.User;
using Book_Store.Domain.Entites;
using Book_Store.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace Book_Store.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Book

            CreateMap<Book, BookListDto>()
                .ForMember(dest => dest.AuthorsFullName, opt => opt.MapFrom(src => src.bookMapAuthors.Select(x => x.Author.FirstName + " " + x.Author.LastName)));

            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.bookMapAuthors))
                .ForMember(dest => dest.Translators, opt => opt.MapFrom(src => src.bookMapTranslators));


            CreateMap<Book, CreateBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();

            #endregion

            #region Book Map Author
            CreateMap<BookMapAuthor, AuthorDto>()
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Author.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Author.LastName))
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AuthorId));
            #endregion

            #region Book Map Translator
            CreateMap<BookMapTranslator, TranslatorDto>()
              .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Translator.FirstName))
              .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Translator.LastName))
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TransLatorId));
            #endregion

            #region Book Image
            CreateMap<BookImage, GetBookImageDto>().ReverseMap();
            #endregion

            #region Author
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, CreateAuthorDto>().ReverseMap();
            CreateMap<Author, UpdateAuthorDto>().ReverseMap();
            #endregion

            #region Translator
            CreateMap<Translator, TranslatorDto>().ReverseMap();
            CreateMap<Translator, CreateTranslatorDto>().ReverseMap();
            CreateMap<Translator, UpdateTranslatorDto>().ReverseMap();
            #endregion

            #region Category
            CreateMap<Category, GetAllCategoryDto>().ReverseMap()
               .ForMember(dest => dest.Children, opt => opt.MapFrom(src => src.Children));

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            #endregion

            #region Publisher
            CreateMap<Publisher, PublisherDto>().ReverseMap();
            CreateMap<Publisher, CreatePublisherDto>().ReverseMap();
            CreateMap<Publisher, UpdatePublisherDto>().ReverseMap();
            #endregion

            #region Comment
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            #endregion

            #region Role

            CreateMap<IdentityRole<int>, RoleDto>();
            CreateMap<IdentityRole<int>, CreateRoleDto>().ReverseMap();
            CreateMap<IdentityRole<int>, UpdateRoleDto>().ReverseMap();
            #endregion

            #region User

            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<ApplicationUser, UserDetailDto>().ReverseMap();

            #endregion

        }
    }
}
