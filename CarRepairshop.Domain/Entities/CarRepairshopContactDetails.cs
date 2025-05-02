using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairshop.Domain.Entities
{
    public class CarRepairshopContactDetails
    {
        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }

        public string? City { get; set; }

        public string? PostalCode { get; set; }
    }
}
