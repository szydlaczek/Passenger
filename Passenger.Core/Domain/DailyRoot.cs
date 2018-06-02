using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Domain
{
    public class DailyRoot
    {
        public Guid Id { get; protected set; }
        public Route Route { get; protected set; }
        public IEnumerable<PassengerNode> PassengerNodes { get; protected set; }
    }
}
