using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Application.Dto;

namespace Application.Mappers
{
    public static class AdoptionMapper
    {
        public static Adoption ToDomain(this AdoptionDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            
            throw new NotImplementedException("Mapping from AdoptionDto to Adoption is not implemented yet.");
        }
        public static AdoptionDto ToDto(this Adoption entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            throw new NotImplementedException("Mapping from Adoption to AdoptionDto is not implemented yet.");
        }
    }
}
