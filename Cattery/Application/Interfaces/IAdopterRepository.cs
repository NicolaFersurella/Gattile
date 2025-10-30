using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.ValueObjects;

namespace Application.Interfaces
{
    public interface IAdopterRepository
    {
        void Add(Adopter adopter);
        void Remove(Adopter adopter);
        Adopter? GetByFcAdopter(FiscalCode fc);
    }
}
