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
    public static class CatMapper
    {
        public static Cat ToDomain(this CatDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            Cat cat = new Cat(
                dto.Name,
                dto.Breed,
                dto.Gender,
                dto.ArrivalDate,
                dto.LeaveDate,
                dto.BirthDate,
                dto.Description
            );

            return cat;
        }

        public static CatDto ToDto(this Cat entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new CatDto(
                entity.Name,
                entity.Breed,
                entity.Gender,
                entity.ArrivalDate,
                entity.LeaveDate,
                entity.BirthDate,
                entity.Description
            );
        }
    }
}
