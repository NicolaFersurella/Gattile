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
        public static Adoption ToDomain(this AdoptionDto dto, Cat cat)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            //Creo l'adozione
            Adoption adoption = new Adoption(
                cat: dto.Cat.ToDomain(),
                adoptionDate: dto.AdoptionDate,
                adopter: dto.Adopter.ToDomain()
            );

            return adoption;
        }
        public static AdoptionDto ToDto(this Adoption entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new AdoptionDto(
                Cat: entity.Cat.ToDto(),
                AdoptionDate: entity.AdoptionDate,
                Adopter: entity.Adopter.ToDto()
            );
        }
    }
}
