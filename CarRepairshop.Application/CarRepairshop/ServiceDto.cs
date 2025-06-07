using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairshop.Application.CarRepairshop
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public TimeSpan EstimatedDuration { get; set; }
    }
}
