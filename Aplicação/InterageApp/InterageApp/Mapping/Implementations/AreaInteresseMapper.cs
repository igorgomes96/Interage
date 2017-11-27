using InterageApp.DTO;
using InterageApp.Mapping.Interfaces;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Mapping.Implementations
{
    public class AreaInteresseMapper : ISingleMapper<AreaInteresse, AreaInteresseDto>
    {
        public AreaInteresseDto Map(AreaInteresse source)
        {
            return source == null ? null : new AreaInteresseDto
            {
                Codigo = source.Codigo,
                Interesse = source.Interesse
            };
        }

        public AreaInteresse Map(AreaInteresseDto destination)
        {
            return destination == null ? null : new AreaInteresse
            {
                Codigo = destination.Codigo,
                Interesse = destination.Interesse
            };
        }

    }
}