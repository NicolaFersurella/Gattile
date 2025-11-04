using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Dto
{
    public record AdopterPersistenceDto(
        string Fc,
        string Name,
        string Surname,
        string Phone,
        string Email,
        string Address,
        string Cap,
        string City
    );
}
