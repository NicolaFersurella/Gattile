using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interfaces;
using Application.Mappers;
using Domain.Model.Entities;

namespace Application.UseCases
{
    public class CatService
    {
        private readonly ICatRepository _repository;

        //Dependency Injection
        public CatService(ICatRepository repository)
        {
            _repository = repository;
        }
        public void CreateCat(CatDto catDto)
        {
            if (string.IsNullOrEmpty(catDto.Name) || string.IsNullOrEmpty(catDto.Breed)) throw new ArgumentException("Invalid cat");
            if (catDto.LeaveDate != null && catDto.ArrivalDate > catDto.LeaveDate) throw new ArgumentException("Invalid arrival date");

            // Verifica se esiste già (business rule → livello application)
            var existing = _repository.GetByCatId(catDto.ToDomain().Id);
            if (existing != null)
                throw new InvalidOperationException($"This cat already exist.");

            // Mapping verso dominio --> mappo CatDto in Cat
            Cat cat = catDto.ToDomain();

            // Persistenza
            _repository.Add(cat);
        }
        public void UpdateCat(CatDto catDto)
        {
            if (string.IsNullOrEmpty(catDto.Name) || string.IsNullOrEmpty(catDto.Breed)) throw new ArgumentException("Invalid cat");
            if (catDto.LeaveDate != null && catDto.ArrivalDate > catDto.LeaveDate) throw new ArgumentException("Invalid arrival date");

            _repository.Update(catDto.ToDomain());
        }
        public void RemoveCatByCatDto(CatDto catDto)
        {
            if (string.IsNullOrEmpty(catDto.Name) || string.IsNullOrEmpty(catDto.Breed)) throw new ArgumentException("Invalid cat");
            if (catDto.LeaveDate != null && catDto.ArrivalDate > catDto.LeaveDate) throw new ArgumentException("Invalid arrival date");

            var exsisting = _repository.GetByCatId(catDto.ToDomain().Id);
            if (exsisting == null)
                throw new InvalidOperationException("Cat not found.");

           _repository.Remove(exsisting);
        }
        public void RemoveCatById(string id)
        {
            var existing = _repository.GetByCatId(id);
            if (existing == null)
                throw new InvalidOperationException("Cat not found.");

            _repository.Remove(id);
        }
        public Cat? GetCatById(string id)
        {
            return _repository.GetByCatId(id);
        }
        public IEnumerable<Cat> GetAllCats()
        {
            return _repository.GetAll();
        }
    }
}
