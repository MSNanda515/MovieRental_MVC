﻿using System;
using AutoMapper;
using MovieRental.Models;
using MovieRental.Dtos;

namespace MovieRental.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}
