using System.ComponentModel.DataAnnotations;

namespace PingYourPackage.API.Model.RequestModels
{
    public abstract class ShipmentBaseRequestModel
    {
        [Required]
        public decimal? Price { get; set; }
        [Required]
        [StringLength(50)]
        public string ReceiverName { get; set; }
        [Required]
        [StringLength(50)]
        public string ReceiverSurname { get; set; }
        [Required]
        [StringLength(50)]
        public string ReceiverAddress { get; set; }
        [Required]
        [StringLength(50)]
        public string ReceiverZipCode { get; set; }
        [Required]
        [StringLength(50)]
        public string ReceiverCity { get; set; }
        [Required]
        [StringLength(50)]
        public string ReceiverCountry { get; set; }
        [Required]
        [StringLength(50)]
        public string ReceiverTelephone { get; set; }
        [Required]
        [StringLength(320)]
        public string ReceiverMail { get; set; }
    }
}
