using Application.Dto;
using Application.Interfaces;
using Application.Mappers;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class AdoptionService
    {
        private readonly IAdoptionRepository _repository;

        //Dependency Injection
        public AdoptionService(IAdoptionRepository repository)
        {
            _repository = repository;
        }
        public void CreateAdoption(AdoptionDto adoptionDto)
        {
            // controllo se il gatto e l'adottante non sono nulli e la data di adozione è valida
            if (adoptionDto.Cat == null || adoptionDto.Adopter == null || adoptionDto.AdoptionDate == default) throw new ArgumentException("Invalid adoption");

            var existingAdoption = _repository.GetById(adoptionDto.Cat.ToDomain().Id); // controllo se esiste l'adozione passandogli l'id del gatto
            if (existingAdoption != null) throw new ArgumentException("Cat already adopted");

            _repository.Add(adoptionDto.ToDomain());
        }
        public void UpdateAdoption(AdoptionDto adoptionDto)
        {
            // controllo se il gatto e l'adottante non sono nulli e la data di adozione è valida
            if (adoptionDto.Cat == null || adoptionDto.Adopter == null || adoptionDto.AdoptionDate == default) throw new ArgumentException("Invalid adoption");

            _repository.Update(adoptionDto.ToDomain());
        }
        public void RemoveAdoption(AdoptionDto adoptionDto)
        {
            if (adoptionDto.Cat == null || adoptionDto.Adopter == null || adoptionDto.AdoptionDate == default) throw new ArgumentException("Invalid adoption");

            var adoption = _repository.GetById(adoptionDto.Cat.ToDomain().Id); // controllo se esiste l'adozione passandogli l'id del gatto
            if (adoption == null) throw new ArgumentException("Adoption not found");

            _repository.Remove(adoptionDto.ToDomain());
        }
        public Adoption? GetAdoptionByIdCat(string id)
        {
            return _repository.GetById(id);
        }
        public IEnumerable<Adoption> GetAdoptionByFiscalCodeAdopter(string fiscalCode)
        {
            return _repository.GetByFiscalCode(fiscalCode);
        }
    }
}
