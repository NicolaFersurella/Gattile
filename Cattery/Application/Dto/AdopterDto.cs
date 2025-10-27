using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public record AdopterDto(
        FiscalCode Fc,
        string Name,
        string Surname,
        PhoneNumber Phone,
        Email Email,
        string Address,
        Cap Cap,
        string City
    );
}
