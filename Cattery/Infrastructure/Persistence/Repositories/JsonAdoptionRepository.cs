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
    public class JsonAdoptionRepository : IAdoptionRepository
    {
        private readonly string _filePath = "adoptions.json";
        // la key è il FiscalCode dell'adottante
        // il value è l'adozioni
        private readonly Dictionary<FiscalCode, Adoption> _cache = new Dictionary<FiscalCode, Adoption>();
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
            var dtos = JsonSerializer.Deserialize<List<AdoptionPersistenceDto>>(json) ?? new List<AdoptionPersistenceDto>();

            //per ogni dto
            foreach (var dto in dtos)
            {
                //lo strasformo in oggetto Adoption
                Adoption adoption = dto.ToDomain(); // Mapper Persistence DTO -> Domain
                //lo aggiungo alla cache
                _cache[adoption.Adopter.Fc] = adoption;
            }

            _initialized = true;
        }
        public void Add(Adoption adoption)
        {
            EnsureLoaded();

            _cache[adoption.Adopter.Fc] = adoption;
            SaveToFile();
        }
        public void Remove(Adoption adoption)
        {
            EnsureLoaded();

            // Controllo esistenza - Repository non fa logica di business si limita a sollevare una exception
            if (!_cache.ContainsKey(adoption.Adopter.Fc))
                throw new InvalidOperationException($"Adopter with fiscal code '{adoption.Adopter.Fc}' not found.");

            //rimuovo l'adopter dalla cache
            _cache.Remove(adoption.Adopter.Fc);
            //rendo persistente la rimozione nel file
            SaveToFile();
        }
        public void ManageFailure(Adoption adoption)
        {
            EnsureLoaded();

            string message = $"(Adozione fallita: {adoption.AdoptionDate})";
            adoption.Cat.LeaveDate = null;
            adoption.Cat.Description = message;


        }
        public Adoption? GetByFiscalCode(FiscalCode fc)
        {
            EnsureLoaded();

            _cache.TryGetValue(fc, out var adoption);
            return adoption;
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
