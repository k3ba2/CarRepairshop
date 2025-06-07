using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairshop.Domain.Entities
{
        public class Appointment
        {
            public int Id { get; set; }

            public DateTime StartTime { get; set; }

            public DateTime EndTime { get; set; }

            public int CustomerId { get; set; }
            public Customer Customer { get; set; }

            public int ServiceId { get; set; }
            public Service Service { get; set; }
        }

    }
