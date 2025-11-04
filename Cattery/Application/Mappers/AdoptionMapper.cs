using Application.Dto;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class AdoptionMapper
    {
        public static Adoption ToDomain(this AdoptionDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            //Creo l'adozione
            return new Adoption(
                dto.Cat.ToDomain(),
                dto.AdoptionDate,
                dto.Adopter.ToDomain()
            );
        }
        public static AdoptionDto ToDto(this Adoption entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new AdoptionDto(
                entity.Cat.ToDto(),
                entity.AdoptionDate,
                entity.Adopter.ToDto()
            );
        }
    }
}
