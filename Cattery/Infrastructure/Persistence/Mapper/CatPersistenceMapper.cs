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
        public static Cat ToDomain(this CatPersistenceDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            Cat cat = new Cat(
                dto.Name,
                dto.Breed,
                dto.Gender,
                dto.ArrivalDate,
                dto.LeaveDate,
                dto.BirthDate,
                dto.Description,
                dto.Adoptions
            );

            return cat;
        }

        public static CatPersistenceDto ToDto(this Cat entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new CatPersistenceDto(
                entity.Name,
                entity.Breed,
                entity.Gender,
                entity.ArrivalDate,
                entity.LeaveDate,
                entity.BirthDate,
                entity.ProbablyYear,
                entity.Description,
                entity.Adoptions?.ToList() //se non è null converte da una readonly a una lista adoption
            );
        }
    }
}
