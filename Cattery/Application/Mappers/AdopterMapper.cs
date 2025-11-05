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
    public static class AdopterMapper
    {
        public static Adopter ToDomain(this AdopterDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            // Creo l'adottante
            return new Adopter(
                dto.Fc,
                dto.Name,
                dto.Surname,
                dto.Phone,
                dto.Email,
                dto.Address,
                dto.Cap,
                dto.City
            );
        }
        public static AdopterDto ToDto(this Adopter entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            // Creo l'adottante DTO
            return new AdopterDto(
                entity.Fc,
                entity.Name,
                entity.Surname,
                entity.Phone,
                entity.Email,
                entity.Address,
                entity.Cap,
                entity.City
            );
        }
    }
}
