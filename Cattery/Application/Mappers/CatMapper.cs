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

            //Creo il gatto senza adozioni
            Cat cat = new Cat(
                name: dto.Name,
                breed: dto.Breed,
                gender: dto.Gender,
                arrivalDate: dto.ArrivalDate,
                leaveDate: dto.LeaveDate,
                birthDate: dto.BirthDate,
                description: dto.Description
            );

            //2️ Creo la lista delle adozioni, associando il gatto concreto
            //per ogni AdoptionDto presente in dto creo un oggetto Adoption
            //e lo metto in una lista
            List<Adoption> adoptionList = new List<Adoption>();
            foreach (AdoptionDto a in dto.Adoptions)
            {
                Adoption adoption = a.ToDomain(cat);
                adoptionList.Add(adoption);
            }

            //3️ Aggiungo le adozioni al gatto
            foreach (var adoption in adoptionList)
            {
                cat.AddAdoption(adoption);
            }

            return cat;
        }
        public static CatDto ToDto(this Cat entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            throw new NotImplementedException("Mapping from Cat to CatDto is not implemented yet.");

        }
    }
}
