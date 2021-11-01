using AutoMapper;
using FourEstate.Core.Dtos;
using FourEstate.Core.ViewModel;
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
            CreateMap<User, UserViewModel>()
                .ForMember(x => x.UserType,x => x.MapFrom(x => x.UserType.ToString()));
            CreateMap<CreateUserDto, User>()
                .ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<UpdateUserDto, User>()
                .ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<User, UpdateUserDto>()
                .ForMember(x => x.Image, x => x.Ignore());

            CreateMap<Category, CategoryViewModel>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, UpdateCategoryDto>();
            CreateMap<CategoryViewModel, paginationViewModel>();

            CreateMap<Location, LocationViewModel>()
                .ForMember(x => x.Status, x => x.MapFrom(x => x.Stauts.ToString()));
            CreateMap<CreateLocationDto, Location>();
            CreateMap<UpdateLocationDto, Location>();
            CreateMap<Location, UpdateLocationDto>();

            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CreateCustomerDto, Customer>()
                .ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<UpdateCustomerDto, Customer>()
                .ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<Customer, UpdateCustomerDto>()
                .ForMember(x => x.ImageUrl, x => x.Ignore());
           
            
            CreateMap<RealEstate, RealEstateViewModel>()
                .ForMember(x => x.Status, x => x.MapFrom(x => x.Stauts.ToString()));
            CreateMap<CreateRealEstateDto, RealEstate>()
                .ForMember(x => x.Attachments, x => x.Ignore());
            CreateMap<UpdateRealEstateDto, RealEstate>()
                .ForMember(x => x.Attachments, x => x.Ignore());
            CreateMap<RealEstate, UpdateRealEstateDto>()
                .ForMember(x => x.Attachments, x => x.Ignore())
                .ForMember(x => x.RealEstateAttachments, x => x.Ignore());
            CreateMap<RealEstatetAttachment, RealEstateAttachmentViewModel>();


            CreateMap<Advertisement, AdvertisementViewModel>()
                .ForMember(x => x.StartDate, x => x.MapFrom(x => x.StartDate.ToString("yyyy:MM:dd")))
                .ForMember(x => x.EndDate, x => x.MapFrom(x => x.EndDate.ToString("yyyy:MM:dd")))
                .ForMember(x => x.Status, x => x.MapFrom(x => x.Stauts.ToString())); 
            CreateMap<CreateAdvertisementDto, Advertisement>()
                .ForMember(x => x.ImageUrl, x => x.Ignore())
                .ForMember(x => x.Owner, x => x.Ignore());
            CreateMap<UpdateAdvertisementDto, Advertisement>()
                .ForMember(x => x.ImageUrl, x => x.Ignore())
                .ForMember(x => x.Owner, x => x.Ignore());
            CreateMap<Advertisement, UpdateAdvertisementDto>()
                .ForMember(x => x.Image, x => x.Ignore());



            /// contracts Mapper
            CreateMap<Contract, ContractViewModel>()
                .ForMember(x => x.Status, x => x.MapFrom(x => x.Stauts.ToString()));
            CreateMap<CreateContractDto, Contract>();
            CreateMap<UpdateContractDto, Contract>();
            CreateMap<Contract, UpdateContractDto>();

            CreateMap<SaleContract, SaleContractViewModel>()
               .ForMember(x => x.Status, x => x.MapFrom(x => x.Stauts.ToString()));
            CreateMap<CreateSaleContractDto, SaleContract>();
            CreateMap<UpdateSaleContractDto, SaleContract>();
            CreateMap<SaleContract, UpdateSaleContractDto>();

            CreateMap<BuyContract, BuyContractViewModel>()
               .ForMember(x => x.Status, x => x.MapFrom(x => x.Stauts.ToString()));
            CreateMap<CreateBuyContractDto, BuyContract>();
            CreateMap<UpdateBuyContractDto, BuyContract>();
            CreateMap<BuyContract, UpdateBuyContractDto>();

            CreateMap<RentContract, RentContractViewModel>()
               .ForMember(x => x.Status, x => x.MapFrom(x => x.Stauts.ToString()));
            CreateMap<CreateRentContractDto, RentContract>();
            CreateMap<UpdateRentContractDto, RentContract>();
            CreateMap<RentContract, UpdateRentContractDto>();

            //////


            CreateMap<ContentChangeLog, ContentChangeLogViewModel>();


            CreateMap<Holiday, HolidayViewModel>()
                .ForMember(x => x.From, x => x.MapFrom(x => x.From.ToString("yyyy:MM:dd")))
                .ForMember(x => x.To, x => x.MapFrom(x => x.To.ToString("yyyy:MM:dd"))); ;
            CreateMap<CreateHolidayDto, Holiday>();
            CreateMap<UpdateHolidayDto, Holiday>();
            CreateMap<Holiday, UpdateHolidayDto>();





            CreateMap<AuctionDb, AuctionDbViewModel>()
                .ForMember(x => x.Status, x => x.MapFrom(x => x.Stauts.ToString()))
                .ForMember(x => x.DOAuction, x => x.MapFrom(x => x.DOAuction.ToString("yyyy:MM:dd")));

            CreateMap<CreateAuctionDto, AuctionDb>()
                .ForMember(x => x.Attachments, x => x.Ignore());
            CreateMap<UpdateAuctionDto, AuctionDb>()
                .ForMember(x => x.Attachments, x => x.Ignore());
            CreateMap<AuctionDb, UpdateAuctionDto>()
                .ForMember(x => x.Attachments, x => x.Ignore())
                .ForMember(x => x.AuctionDbAttchment, x => x.Ignore());
            CreateMap<AuctionDbAttachment,AuctionDbAttchmentViewModel>();






            CreateMap<Invoice, InvoiceViewModel>();
                //.ForMember(x => x.InvoiceDate, x => x.MapFrom(x => x.InvoiceDate.ToString("yyyy:MM:dd");
            CreateMap<CreateInvoiceDto, Invoice>();
            CreateMap<UpdateInvoiceDto, Invoice>();
            CreateMap<Invoice, UpdateInvoiceDto>();


            CreateMap<Receipt, ReceiptViewModel>()
             .ForMember(x => x.DateTimeStart, x => x.MapFrom(x => x.DateTimeStart.ToString("yyyy:MM:dd")))
             .ForMember(x => x.DateTimeEnd, x => x.MapFrom(x => x.DateTimeEnd.ToString("yyyy:MM:dd")))
             .ForMember(x => x.DateReceipt, x => x.MapFrom(x => x.DateReceipt.ToString("yyyy:MM:dd")));

            CreateMap<CreateReceiptDto, Receipt>();
            CreateMap<UpdateReceiptDto, Receipt>();
            CreateMap<Receipt, UpdateReceiptDto>();



            CreateMap<CatchReceipt, CatchReceiptViewModel>()
             .ForMember(x => x.DateTimeStart, x => x.MapFrom(x => x.DateTimeStart.ToString("yyyy:MM:dd")))
             .ForMember(x => x.DateTimeEnd, x => x.MapFrom(x => x.DateTimeEnd.ToString("yyyy:MM:dd")))
             .ForMember(x => x.DateReceipt, x => x.MapFrom(x => x.DateReceipt.ToString("yyyy:MM:dd")));

            CreateMap<CreateCatchReceiptDto, CatchReceipt>();
            CreateMap<UpdateCatchReceiptDto, CatchReceipt>();
            CreateMap<CatchReceipt, UpdateCatchReceiptDto>();

        }
    }
}
