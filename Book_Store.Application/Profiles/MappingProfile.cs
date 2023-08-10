using AutoMapper;
using Book_Store.Application.DTOs;
using Book_Store.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book,BookDto>().ReverseMap();
            CreateMap<Author,AuthorDto>().ReverseMap();
            CreateMap<Category,BookDto>().ReverseMap();
            CreateMap<Publisher,PublisherDto>().ReverseMap();
        }
    }
}
