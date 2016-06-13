using System;
using System.ComponentModel.DataAnnotations;

namespace PingYourPackage.API.Model.RequestModels
{
    public class ShipmentRequestModel : ShipmentBaseRequestModel
    {
        [Required]
        public Guid? AffiliateKey { get; set; }
        [Required]
        public Guid? ShipmentTypeKey { get; set; }
    }
}
