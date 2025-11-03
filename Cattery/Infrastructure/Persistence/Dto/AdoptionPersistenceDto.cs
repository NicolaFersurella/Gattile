using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Dto
{
    public record AdoptionPersistenceDto(
        CatPersistenceDto Cat,
        DateTime AdoptionDate,
        AdopterPersistenceDto Adopter
    );
}
