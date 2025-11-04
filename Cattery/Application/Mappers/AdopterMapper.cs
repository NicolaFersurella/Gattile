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

            //Creo l'adottante
            return new Adopter(
                new FiscalCode(dto.Fc),
                dto.Name,
                dto.Surname,
                new PhoneNumber(dto.Phone),
                new Email(dto.Email),
                dto.Address,
                new Cap(dto.Cap),
                dto.City
            );
        }
        public static AdopterDto ToDto(this Adopter entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new AdopterDto(
                entity.Fc.Value,
                entity.Name,
                entity.Surname,
                entity.Phone.Value,
                entity.Email.Value,
                entity.Address,
                entity.Cap.Value,
                entity.City
            );
        }
    }
}
