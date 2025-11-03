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
    public static class AdopterPersistenceMapper
    {
        public static AdopterPersistenceDto ToDto(this Adopter entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new AdopterPersistenceDto(
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
        public static Adopter ToDomain(this AdopterPersistenceDto dto)
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
    }
}
