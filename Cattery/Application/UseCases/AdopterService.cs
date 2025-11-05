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
            if (string.IsNullOrEmpty(adopterDto.Name) || string.IsNullOrEmpty(adopterDto.Surname) || string.IsNullOrEmpty(adopterDto.Address) || string.IsNullOrEmpty(adopterDto.City)) throw new ArgumentException("Invalid adopter");

            // Verifica se esiste già (business rule → livello application)
            var existing = _repository.GetByFiscalCode(adopterDto.Fc);
            if (existing != null)
                throw new InvalidOperationException("This adopter already exist.");

            // Mapping verso dominio --> mappo CatDto in Cat
            Adopter adopter = adopterDto.ToDomain();

            // Persistenza
            _repository.Add(adopter);
        }
        public void UpdateAdopter(AdopterDto adopterDto)
        {
            _repository.Update(adopterDto.ToDomain());
        }
        public void RemoveAdopter(AdopterDto adopterDto)
        {
            if (string.IsNullOrEmpty(adopterDto.Name) || string.IsNullOrEmpty(adopterDto.Surname) || string.IsNullOrEmpty(adopterDto.Address) || string.IsNullOrEmpty(adopterDto.City)) throw new ArgumentException("Invalid adopter");

            var entity = _repository.GetByFiscalCode(adopterDto.Fc);
            if (entity == null)
                throw new InvalidOperationException("Adopter not found.");

            _repository.Remove(entity);
        }
        public Adopter? GetAdopterByFiscalCode(FiscalCode fiscalCode)
        {
            return _repository.GetByFiscalCode(fiscalCode);
        }
    }
}
