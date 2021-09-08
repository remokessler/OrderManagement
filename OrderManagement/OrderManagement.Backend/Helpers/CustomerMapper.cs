using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AutoMapper;
using OrderManagement.Backend.DataModels;
using OrderManagement.Backend.Serializer.DTOs;

namespace OrderManagement.Backend.Helpers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.customerNr, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Firstname + " " + src.Name))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Mail))
                .ForMember(dest => dest.website, opt => opt.MapFrom(src => src.Webpage))
                .ForMember(dest => dest.address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.password, opt => opt.MapFrom(src => Encoding.UTF8.GetBytes(src.Password)));

            CreateMap<CustomerDTO, Customer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.customerNr))
                .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.name.Split(' ', StringSplitOptions.None)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name.Split(' ', StringSplitOptions.None)))
                .ForMember(dest => dest.Mail, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.Webpage, opt => opt.MapFrom(src => src.website))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.address))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => Encoding.UTF8.GetString(src.password)));
        }
    }
}
