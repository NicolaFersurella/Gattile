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
        Cat? GetByNameCat(string name);
        List<Cat> GetAll();
    }
}
