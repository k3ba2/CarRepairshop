using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairshop.Domain.Entities
{
    public class ArchivedCarRepairshop
    {
        [Key]
        public int? CarRepairshopId { get; set; }

        public string? Name { get; set; }

        public DateTime DeleteDate { get; set; }
    }
}
