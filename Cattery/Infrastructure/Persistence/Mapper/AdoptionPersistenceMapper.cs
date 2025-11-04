using Application.Mappers;
using Domain.Model.Entities;
using Infrastructure.Persistence.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Mapper
{
    public static class AdoptionPersistenceMapper
    {
        public static Adoption ToDomain(this AdoptionPersistenceDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            //Creo l'adozione
            return new Adoption(
                dto.Cat.ToDomain(),
                dto.AdoptionDate,
                dto.Adopter.ToDomain()
            );
        }
        public static AdoptionPersistenceDto ToDto(this Adoption entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new AdoptionPersistenceDto(
                entity.Cat.ToDto(),
                entity.AdoptionDate,
                entity.Adopter.ToDto()
            );
        }
    }
}
