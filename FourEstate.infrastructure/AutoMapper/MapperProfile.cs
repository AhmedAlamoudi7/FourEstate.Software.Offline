using AutoMapper;
using FourEstate.Core.Dtos;
using FourEstate.Core.ViewModels;
using FourEstate.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Infrastructure.AutoMapper
{

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserViewModel>().ForMember(x => x.UserType,x => x.MapFrom(x => x.UserType.ToString()));
            CreateMap<CreateUserDto, User>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<UpdateUserDto, User>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<User, UpdateUserDto>().ForMember(x => x.Image, x => x.Ignore());

            CreateMap<Category, CategoryViewModel>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, UpdateCategoryDto>();

            CreateMap<Location, LocationViewModel>();
            CreateMap<CreateLocationDto, Location>();
            CreateMap<UpdateLocationDto, Location>();
            CreateMap<Location, UpdateLocationDto>();

            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CreateCustomerDto, Customer>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<UpdateCustomerDto, Customer>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<Customer, UpdateCustomerDto>().ForMember(x => x.ImageUrl, x => x.Ignore());
           
            
            CreateMap<RealEstate, RealEstateViewModel>();
            CreateMap<CreateRealEstateDto, RealEstate>().ForMember(x => x.Images, x => x.Ignore());
            CreateMap<UpdateRealEstateDto, RealEstate>().ForMember(x => x.Images, x => x.Ignore());
            CreateMap<RealEstate, UpdateRealEstateDto>().ForMember(x => x.Images, x => x.Ignore());
        }
    }
}
