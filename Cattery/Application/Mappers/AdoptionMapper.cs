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
                cat: dto.Cat,
                adoptionDate: dto.AdoptionDate,
                adopter: dto.Adopter
            );

            throw new NotImplementedException("Mapping from AdoptionDto to Adoption is not implemented yet.");
        }
        public static AdoptionDto ToDto(this Adoption entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            throw new NotImplementedException("Mapping from Adoption to AdoptionDto is not implemented yet.");
        }
    }
}
