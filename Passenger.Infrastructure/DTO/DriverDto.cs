﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Infrastructure.DTO
{
    public class DriverDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public VehicleDto Vehicle { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
