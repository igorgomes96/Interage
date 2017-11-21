using InterageApp.DTO;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Mapping
{
    public class AreaInteresseMapper : IMapper<AreaInteresse, AreaInteresseDto>
    {
        public AreaInteresseDto Map(AreaInteresse source)
        {
            return new AreaInteresseDto
            {
                Codigo = source.Codigo,
                Interesse = source.Interesse
            };
        }

        public AreaInteresse Map(AreaInteresseDto destination)
        {
            return new AreaInteresse
            {
                Codigo = destination.Codigo,
                Interesse = destination.Interesse
            };
        }

        public ICollection<AreaInteresseDto> Map(ICollection<AreaInteresse> source)
        {
            return source.Select(x => Map(x)).ToList();
        }

        public ICollection<AreaInteresse> Map(ICollection<AreaInteresseDto> destination)
        {
            return destination.Select(x => Map(x)).ToList();
        }
    }
}