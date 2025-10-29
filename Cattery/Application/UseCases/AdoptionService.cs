using Application.Dto;
using Application.Interfaces;
using Application.Mappers;
using Domain.Model.Entities;
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
            if (adoptionDto.Cat == null || adoptionDto.Adopter == null || adoptionDto.AdoptionDate == default) throw new ArgumentException("Invalid adoption");

            // Verifica se esiste già (business rule → livello application)
            var existing = _repository.GetByCatAdoption(adoptionDto.Cat);
            if (existing != null)
                throw new InvalidOperationException($"This adopter already exist.");

            // Mapping verso dominio --> mappo AdoptionDto in Adoption
            Adoption adoption = adoptionDto.ToDomain();

            // Persistenza
            _repository.Add(adoption);
        }
        public void ManageFailure(AdoptionDto adoptionDto)
        {
            if (adoptionDto.Cat == null) throw new ArgumentException("Invalid adoption");

            var entity = _repository.GetByCatAdoption(adoptionDto.Cat);
            if (entity == null)
                throw new InvalidOperationException("Adoption not found.");

            _repository.ManageFailure(entity);
        }
        public AdoptionDto? GetByCat(Cat cat)
        {
            var entity = _repository.GetByCatAdoption(cat);
            return entity?.ToDto();
        }
    }
}
