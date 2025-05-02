using CarRepairshop.Application.CarRepairshop.Queries.GetCarRepairshoById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairshop.Application.CarRepairshop
{
    public class CarRepairshopOpeningHourDto
    {
        public int CarRepairshopId { get; set; }

        public string OpeningDays { get; set; }

        public DateTime OpeningHour { get; set; }
        public DateTime ClosingHour { get; set; }
    }
}
