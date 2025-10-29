using Application.Dto;
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
        public static AdoptionPersistenceDto ToDto(this Adoption entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new AdoptionPersistenceDto(
                Cat: entity.Cat,
                AdoptionDate: entity.AdoptionDate,
                Adopter: entity.Adopter
            );
        }
        public static Adoption ToEntity(this AdoptionPersistenceDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            //Creo l'adozione
            Adoption adoption = new Adoption(
                cat: dto.Cat,
                adoptionDate: dto.AdoptionDate,
                adopter: dto.Adopter
            );

            return adoption;
        }
    }
}
