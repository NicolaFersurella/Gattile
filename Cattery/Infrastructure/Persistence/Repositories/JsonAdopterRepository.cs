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
    public class JsonAdopterRepository : IAdopterRepository
    {
        private readonly string _filePath = "adopters.json";
        //La chiave del dizionario è il FiscalCode del adopter. Il valore è l’entità di dominio Adopter.
        //Le operazioni di un adopter vengono svolte in O(1).
        //StringComparer.OrdinalIgnoreCase Serve a rendere la chiave case-insensitive.
        private readonly Dictionary<FiscalCode, Adopter> _cache = new Dictionary<FiscalCode, Adopter>();
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
            var dtos = JsonSerializer.Deserialize<List<AdopterPersistenceDto>>(json) ?? new List<AdopterPersistenceDto>();

            //per ogni dto
            foreach (var dto in dtos)
            {
                //lo strasformo in oggetto adopter
                Adopter adopter = dto.ToDomain(); // Mapper Persistence DTO -> Domain
                //lo aggiungo alla cache
                _cache[adopter.Fc] = adopter;
            }

            _initialized = true;
        }
        public void Add(Adopter adopter)
        {
            EnsureLoaded();

            // Controllo duplicati case-insensitive - Repository non fa logica di business si limita a sollevare una exception
            if (_cache.ContainsKey(adopter.Fc))
                throw new InvalidOperationException($"Adopter '{adopter.Fc}' already exist.");

            //aggiungo l'adopter alla cache
            _cache[adopter.Fc] = adopter;
            //rendo persistente l'aggiunta nel file
            SaveToFile();
        }
        public Adopter? GetByFiscalCode(FiscalCode fc)
        {
            EnsureLoaded();

            Adopter? adopter;
            _cache.TryGetValue(fc, out adopter);

            return adopter;
        }
        public void Remove(Adopter adopter)
        {
            EnsureLoaded();

            // Controllo esistenza - Repository non fa logica di business si limita a sollevare una exception
            if (!_cache.ContainsKey(adopter.Fc))
                throw new InvalidOperationException($"Adopter '{adopter.Fc}' not found.");

            //rimuovo l'adopter dalla cache
            _cache.Remove(adopter.Fc);
            //rendo persistente la rimozione nel file
            SaveToFile();
        }
        private void SaveToFile()
        {
            /*
             * _cache.Values --> tutti i cat del dictionary
             * c => c.ToPersistenceDto() --> per ogni cat restituisce il dto di persistenza
             * dtos è la lista di tutti i dto dei cat presenti nella cache
             */
            var dtos = _cache.Values.Select(a => a.ToDto()).ToList();
            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
