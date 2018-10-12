using AutoMapper;
using swag.Core.Domain;
using swag.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace swag.Core.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Cards, CardDTO>();
            });

            return config.CreateMapper();
        }
    }
}
