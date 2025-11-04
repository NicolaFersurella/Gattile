using Application.Mappers;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Infrastructure.Persistence.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Mapper
{
    public static class AdopterPersistenceMapper
    {
        public static Adopter ToDomain(this AdopterPersistenceDto dto)
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
        public static AdopterPersistenceDto ToDto(this Adopter entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new AdopterPersistenceDto(
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
