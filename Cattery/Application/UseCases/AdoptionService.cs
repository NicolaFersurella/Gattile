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

            var existingAdoption = _repository.GetByCatId(adoptionDto.Cat.Id);
            if (existingAdoption != null) throw new ArgumentException("Cat already adopted");

            _repository.Add(adoptionDto.ToDomain(adoptionDto.Cat));
        }
        public void RemoveAdoption(AdoptionDto adoptionDto)
        {
            if (adoptionDto.Cat == null || adoptionDto.Adopter == null || adoptionDto.AdoptionDate == default) throw new ArgumentException("Invalid adoption");

            var adoption = _repository.GetByCatId(adoptionDto.Cat.Id);
            if (adoption == null) throw new ArgumentException("Cat not found");

            _repository.Remove(adoptionDto.ToDomain(adoptionDto.Cat));
            _repository.ManageFailure(adoptionDto.ToDomain(adoptionDto.Cat));
        }
    }
}
