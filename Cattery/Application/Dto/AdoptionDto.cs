using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;

namespace Application.Dto
{
    public record AdoptionDto(
        CatDto Cat,
        DateTime AdoptionDate,
        AdopterDto Adopter
    );
}
