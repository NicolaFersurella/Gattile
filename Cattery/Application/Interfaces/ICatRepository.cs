using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICatRepository
    {
        void Add(Cat cat);
        void Update(Cat cat);
        void Remove(Cat cat);
        void Remove(string id);
        Cat? GetByCatId(string id);
        IEnumerable<Cat> GetAll();
    }
}
