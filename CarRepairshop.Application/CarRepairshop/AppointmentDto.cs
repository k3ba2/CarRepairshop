using CarRepairshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairshop.Application.CarRepairshop
{
    public class AppointmentDto
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int CustomerId { get; set; }

        public int ServiceId { get; set; }
    }
}
