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
    public class AdopterService
    {
        private readonly IAdopterRepository _repository;

        //Dependency Injection
        public AdopterService(IAdopterRepository repository)
        {
            _repository = repository;
        }
        public void CreateAdopter(AdopterDto adopterDto)
        {
            if (string.IsNullOrEmpty(adopterDto.Name) || string.IsNullOrEmpty(adopterDto.Surname) || string.IsNullOrEmpty(adopterDto.Name) || string.IsNullOrEmpty(adopterDto.City)) throw new ArgumentException("Invalid adopter");

            // Verifica se esiste già (business rule → livello application)
            var existing = _repository.GetByNameAdopter(adopterDto.Name);
            if (existing != null)
                throw new InvalidOperationException($"This adopter already exist.");

            // Mapping verso dominio --> mappo CatDto in Cat
            Adopter adopter = adopterDto.ToDomain();

            // Persistenza
            _repository.Add(adopter);
        }
        public AdopterDto? GetByName(string name)
        {
            var entity = _repository.GetByNameAdopter(name);
            return entity?.ToDto();
        }
        public void RemoveAdopter(AdopterDto adopterDto)
        {
            if (string.IsNullOrEmpty(adopterDto.Name) || string.IsNullOrEmpty(adopterDto.Surname) || string.IsNullOrEmpty(adopterDto.Name) || string.IsNullOrEmpty(adopterDto.City)) throw new ArgumentException("Invalid adopter");

            var entity = _repository.GetByNameAdopter(adopterDto.Name);
            if (entity == null)
                throw new InvalidOperationException("Adopter not found.");

            _repository.Remove(entity);
        }
    }
}
