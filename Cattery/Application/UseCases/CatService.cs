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
            if (catDto.LeaveDate == null && catDto.ProbablyYear < 1) throw new ArgumentException("Invalid probably year");

            // Verifica se esiste già (business rule → livello application)
            var existing = _repository.GetByNameCat(catDto.Name);
            if (existing != null)
                throw new InvalidOperationException($"This cat already exist.");

            // Mapping verso dominio --> mappo CatDto in Cat
            Cat cat = catDto.ToDomain();

            // Persistenza
            _repository.Add(cat);
        }
        public CatDto? GetByName(string name)
        {
            var entity = _repository.GetByNameCat(name);
            return entity?.ToDto();
        }
        public List<CatDto> ViewAll()
        {
            List<CatDto> dtos = new List<CatDto>();

            foreach (Cat c in _repository.GetAll())
            {
                dtos.Add(c.ToDto());
            }
            return dtos;
        }
    }
}
