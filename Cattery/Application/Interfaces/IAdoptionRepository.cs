using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAdoptionRepository
    {
        void Add(Adoption adoption);
        void Update(Adoption adoption);
        void Remove(Adoption adoption);
        Adoption? GetById(string id);
        IEnumerable<Adoption> GetByFiscalCode(FiscalCode fiscalCode);
        
    }
}
