using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairshop.Application.CarRepairshop.Commands.CreateCarRepairshop
{
    public class CreateCarRepairshopCommand : CarRepairshopDto, IRequest
    {
        //public string Name { get; set; } = default!;
        //public string? Description { get; set; }

        //public string? About { get; set; }
        //public string? PhoneNumber { get; set; }
        //public string? Street { get; set; }

        //public string? City { get; set; }

        //public string? PostalCode { get; set; }

        //public string EncodedName { get; set; }

        //public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-");
    }
}
