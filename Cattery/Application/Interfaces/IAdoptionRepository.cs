using Domain.Model.Entities;
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
        void ManageFailure(Adoption adoption);
        Adoption? GetByCatAdoption(Cat cat);
    }
}
