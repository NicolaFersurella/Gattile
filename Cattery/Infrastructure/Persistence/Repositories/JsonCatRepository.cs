using Application.Interfaces;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Infrastructure.Persistence.Dto;

namespace Infrastructure.Persistence.Repositories
{
    public class JsonCatRepository : ICatRepository
    {
        private readonly string _filePath = "cats.json";
        //La chiave del dizionario è l'ID (string) del gatto. Il valore è l’entità di dominio Cat.
        //Le operazioni di un cat vengono svolte in O(1).
        //StringComparer.OrdinalIgnoreCase Serve a rendere la chiave case-insensitive.
        private readonly Dictionary<string, Cat> _cache = new(StringComparer.OrdinalIgnoreCase);
        private bool _initialized = false;

        /// <summary>
        /// Garantisce che la cache sia popolata leggendo il file JSON solo una volta.
        /// </summary>
        private void EnsureLoaded()
        {
            if (_initialized) return;

            if (!File.Exists(_filePath))
            {
                _initialized = true;
                return;
            }

            //se non ho ancora letto il file
            //tiro fuori il contenuto dle file sotto forma di stringa
            var json = File.ReadAllText(_filePath);
            //deserializzo il contenuto del file in una lista di dto
            var dtos = JsonSerializer.Deserialize<List<CatPersistenceDto>>(json) ?? new List<CatPersistenceDto>();

            //per ogni dto
            foreach (var dto in dtos)
            {
                //lo strasformo in oggetto cat
                //Animal animal = dto.ToEntity(); // Mapper Persistence DTO -> Domain
                                                //lo aggiungo alla cache
                //_cache[animal.Name] = animal;
            }

            _initialized = true;
        }
        public void Add(Cat cat)
        {
            EnsureLoaded();
            throw new NotImplementedException();
        }
        public List<Cat> GetAll()
        {
            EnsureLoaded();
            return _cache.Values.ToList();
        }
        public Cat? GetByNameCat(string name)
        {
            EnsureLoaded();

            Cat? cat;
            _cache.TryGetValue(name, out cat);
            return cat;
        }
    }
}
