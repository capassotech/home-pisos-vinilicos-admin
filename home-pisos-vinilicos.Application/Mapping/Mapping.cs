using AutoMapper;
using home_pisos_vinilicos_admin.Domain;
using home_pisos_vinilicos_admin.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace home_pisos_vinilicos.Application.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {

            CreateMap<Product, ProductDto>().ReverseMap();

        }
    }

}
