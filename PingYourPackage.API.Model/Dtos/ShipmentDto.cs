﻿using System;
using System.Collections.Generic;

namespace PingYourPackage.API.Model.Dtos
{
    public class ShipmentDto : IDto
    {
        public Guid Key { get; set; }
        public Guid AffiliateKey { get; set; }

        public decimal Price { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverSurname { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverZipCode { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverCountry { get; set; }
        public string ReceiverTelephone { get; set; }
        public string ReceiverMail { get; set; }
        public DateTime CreateOn { get; set; }

        public ShipmentTypeDto ShipmentType { get; set; }
        public IEnumerable<ShipmentStateDto> ShipmentStates { get; set; }
    }
}
