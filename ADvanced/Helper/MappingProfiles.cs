using ADvanced.Dto;
using ADvanced.Models;
using AutoMapper;

namespace ADvanced.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
    }
}