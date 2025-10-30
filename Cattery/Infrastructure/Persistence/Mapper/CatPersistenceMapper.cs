using Application.Dto;
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
    public static class CatPersistenceMapper
    {
        public static CatPersistenceDto ToDto(this Cat entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new CatPersistenceDto(
                Name: entity.Name,
                Breed: entity.Breed,
                Gender: entity.Gender,
                ArrivalDate: entity.ArrivalDate,
                LeaveDate: entity.LeaveDate,
                BirthDate: entity.BirthDate,
                ProbablyYear: entity.ProbablyYear,
                Description: entity.Description,
                Adoptions: entity.Adoptions?.ToList() //se non è null converte da una readonly a una lista adoption
            );
        }
        public static Cat ToDomain(this CatPersistenceDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            Cat cat = new Cat(
                name: dto.Name,
                breed: dto.Breed,
                gender: dto.Gender,
                arrivalDate: dto.ArrivalDate,
                leaveDate: dto.LeaveDate,
                birthDate: dto.BirthDate,
                description: dto.Description,
                adoptions: dto.Adoptions
            );

            return cat;
        }
    }
}
