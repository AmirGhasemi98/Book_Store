using AutoMapper;
using Book_Store.Application.DTOs.Author;
using Book_Store.Application.DTOs.Book;
using Book_Store.Application.DTOs.Category;
using Book_Store.Application.DTOs.Comment;
using Book_Store.Application.DTOs.Publisher;
using Book_Store.Application.DTOs.User;
using Book_Store.Domain.Entites;

namespace Book_Store.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Book
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, CreateBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();

            #endregion

            #region Author
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, CreateAuthorDto>().ReverseMap();
            CreateMap<Author, UpdateAuthorDto>().ReverseMap();
            #endregion

            #region Category
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

            #region User
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            #endregion

        }
    }
}
