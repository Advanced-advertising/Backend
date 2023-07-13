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
        CreateMap<Ad, AdDto>();
        CreateMap<AdDto, Ad>();
        CreateMap<Address, AddressDto>();
        CreateMap<AddressDto, Address>();
        CreateMap<AdOrder, AdOrderDto>();
        CreateMap<AdOrderDto, AdOrder>();
        CreateMap<Business, BusinessDto>();
        CreateMap<BusinessDto, Business>();
        CreateMap<BusinessWorkingTime, BusinessWorkingTimeDto>();
        CreateMap<BusinessWorkingTimeDto, BusinessWorkingTime>();
        CreateMap<Income, IncomeDto>();
        CreateMap<IncomeDto, Income>();
        CreateMap<Payment, PaymentDto>();
        CreateMap<PaymentDto, Payment>();
        CreateMap<Screen, ScreenDto>();
        CreateMap<ScreenDto, Screen>();
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
    }
}