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
            Adopter adopter = new Adopter(
                fc: dto.Fc,
                name: dto.Name,
                surname: dto.Surname,
                number: dto.Phone,
                email: dto.Email,
                address: dto.Address,
                cap: dto.Cap,
                city: dto.City
            );

            return adopter;
        }
        public static AdopterDto ToDto(this Adopter entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new AdopterDto(
                Fc: entity.Fc,
                Name: entity.Name,
                Surname: entity.Surname,
                Phone: entity.Phone,
                Email: entity.Email,
                Address: entity.Address,
                Cap: entity.Cap,
                City: entity.City
            );
        }
    }
}
