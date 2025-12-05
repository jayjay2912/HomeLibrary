using AutoMapper;
using Gemstone.HomeLibrary.Dto;
using Gemstone.HomeLibrary.Models;

namespace Gemstone.HomeLibrary.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDto>();
    }
}
