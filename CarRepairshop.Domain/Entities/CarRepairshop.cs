﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairshop.Domain.Entities
{
    public class CarRepairshop
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? About { get; set; }

        public string? CreatedById { get; set; }

        public string? EncodedName { get; private set; } = default!;

        public CarRepairshopContactDetails ContactDetails { get; set; } = default!;

        public List<CarRepairshopOpeningHour> CarRepairshopOpeningHours { get; set; } = new List<CarRepairshopOpeningHour>();

        public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-");
    }
}
