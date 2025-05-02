using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairshop.Domain.Entities
{
    public class CarRepairshopOpeningHour
    {
        public  int Id { get; set; }
        public int CarRepairshopId { get; set; }

        public CarRepairshop CarRepairshops { get; set; }

        public string OpeningDays { get; set; }

        public DateTime OpeningHour { get; set; }
        public DateTime ClosingHour { get; set; }
    }
}
