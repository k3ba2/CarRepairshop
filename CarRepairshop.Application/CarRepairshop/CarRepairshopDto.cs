using CarRepairshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairshop.Application.CarRepairshop
{
    public class CarRepairshopDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }

        public string? About { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }

        public string? City { get; set; }

        public string? PostalCode { get; set; }

        public string? EncodedName { get; set; }

        public List<CarRepairshopOpeningHourDto> OpeningHours { get; set; } = new List<CarRepairshopOpeningHourDto>();
    }
}
