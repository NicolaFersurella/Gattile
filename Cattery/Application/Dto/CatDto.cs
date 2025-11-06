using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public record CatDto(
        string Name,
        string Breed,
        Gender Gender,
        DateTime ArrivalDate,
        DateTime? LeaveDate,
        DateTime? BirthDate,
        //int? ProbablyYear,
        string? Description
        //List<Adoption>? Adoptions = null
    );
}
