using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.DTO.ResultsDto;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierInputModelDto, Supplier>();

            this.CreateMap<PartInputModelDto, Part>();

            this.CreateMap<CustomerInputModelDto, Customer>();

            this.CreateMap<SaleInputModelDto, Sale>();

            this.CreateMap<Customer, CarOutputModelDto>();

            this.CreateMap<CarOutputModelDto, Customer>();
        }
    }
}
