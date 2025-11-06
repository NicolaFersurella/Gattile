using Application.Interfaces;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Infrastructure.Persistence.Dto;
using Infrastructure.Persistence.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
                Cat cat = dto.ToDomain(); // Mapper Persistence DTO -> Domain
                                                //lo aggiungo alla cache
                _cache[cat.Id] = cat;
            }

            _initialized = true;
        }
        public void Add(Cat cat)
        {
            EnsureLoaded();

            // Controllo duplicati case-insensitive - Repository non fa logica di business si limita a sollevare una exception
            if (_cache.ContainsKey(cat.Id))
                throw new InvalidOperationException($"Cat '{cat.Id}' already exist.");

            //aggiungo il gatto alla cache
            _cache[cat.Id] = cat;
            //rendo persistente l'aggiunta nel file
            SaveToFile();
        }
        public void Update(Cat cat)
        {
            EnsureLoaded();

            // Controllo esistenza - Repository non fa logica di business si limita a sollevare una exception
            if (!_cache.ContainsKey(cat.Id))
                throw new InvalidOperationException($"Cat '{cat.Id}' not found.");

            //aggiorno il gatto nella cache
            _cache[cat.Id] = cat;

            //rendo persistente l'aggiornamento nel file
            SaveToFile();
        }
        public void Remove(Cat cat)
        {
            EnsureLoaded();

            // Controllo esistenza - Repository non fa logica di business si limita a sollevare una exception
            if (!_cache.ContainsKey(cat.Id))
                throw new InvalidOperationException($"Cat '{cat.Id}' not found.");

            //rimuovo il gatto dalla cache
            _cache.Remove(cat.Id);

            //rendo persistente la rimozione nel file
            SaveToFile();
        }
        public void Remove(string id)
        {
            EnsureLoaded();

            // Controllo esistenza - Repository non fa logica di business si limita a sollevare una exception
            if (!_cache.ContainsKey(id))
                throw new InvalidOperationException($"Cat '{id}' not found.");

            //rimuovo il gatto dalla cache
            _cache.Remove(id);

            //rendo persistente la rimozione nel file
            SaveToFile();
        }
        public Cat? GetByCatId(string id)
        {
            EnsureLoaded();

            Cat? cat;
            _cache.TryGetValue(id, out cat);
            return cat;
        }
        public IEnumerable<Cat> GetAll()
        {
            EnsureLoaded();

            return _cache.Values;
        }
        private void SaveToFile()
        {
            /*
             * _cache.Values --> tutti i cat del dictionary
             * c => c.ToPersistenceDto() --> per ogni cat restituisce il dto di persistenza
             * dtos è la lista di tutti i dto dei cat presenti nella cache
             */
            var dtos = _cache.Values.Select(c => c.ToDto()).ToList();
            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
