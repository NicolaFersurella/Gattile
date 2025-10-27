using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Domain.Model.Entities;

namespace Application.Mappers
{
    public static class CatMapper
    {
        public static Cat ToDomain(this CatDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            //Creo il gatto
            Cat cat = new Cat(
                name: dto.Name,
                breed: dto.Breed,
                gender: dto.Gender,
                arrivalDate: dto.ArrivalDate,
                leaveDate: dto.LeaveDate,
                birthDate: dto.BirthDate,
                description: dto.Description
            );

            //Creo le liste delle visite, associando il Cat
            //per ogni AdoptionDto presente in dto creo un oggetto Adoption
            //e lo metto in una lista
            throw new NotImplementedException();
        }
        public static CatDto ToDto(this Cat entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            throw new NotImplementedException("Mapping from Cat to CatDto is not implemented yet.");
        }
    }
}
