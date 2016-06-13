using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PingYourPackage.API.Model.Dtos
{
    public class ShipmentTypeDto : IDto
    {
        public Guid Key { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
