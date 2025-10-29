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

            List<AdoptionDto> adoption = new List<AdoptionDto>();
            foreach (Adoption a in entity.Adoptions)
            {
                AdoptionDto adoptionDto = a.ToDto();
                adoption.Add(adoptionDto);
            }

            return new CatPersistenceDto(
                Name: entity.Name,
                Breed: entity.Breed,
                Gender: entity.Gender,
                ArrivalDate: entity.ArrivalDate,
                LeaveDate: entity.LeaveDate,
                BirthDate: entity.BirthDate,
                ProbablyYear: entity.ProbablyYear,
                Description: entity.Description,
                Adoptions: adoption
            );
        }
        public static Cat ToEntity(this CatPersistenceDto dto)
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
    }
}
