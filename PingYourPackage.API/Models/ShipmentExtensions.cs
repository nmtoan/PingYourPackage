using PingYourPackage.API.Model.Dtos;
using PingYourPackage.Domain.Entities;
using System.Linq;

namespace PingYourPackage.API.Models
{
    internal static class ShipmentExtensions
    {
        internal static ShipmentDto ToShipmentDto(this Shipment shipment)
        {
            return new ShipmentDto
            {
                Key = shipment.Key,
                AffiliateKey = shipment.AffiliateKey,
                Price = shipment.Price,
                ReceiverName = shipment.ReceiverName,
                ReceiverSurname = shipment.ReceiverSurname,
                ReceiverAddress = shipment.ReceiverAddress,
                ReceiverZipCode = shipment.ReceiverZipCode,
                ReceiverCity = shipment.ReceiverCity,
                ReceiverCountry = shipment.ReceiverCountry,
                ReceiverMail = shipment.ReceiverMail,
                ReceiverTelephone = shipment.ReceiverTelephone,
                CreateOn = shipment.CreateOn,
                ShipmentType = shipment.ShipmentType.ToShipmentTypeDto(),
                ShipmentStates = shipment.ShipmentStates.Select(ss => ss.ToShipmentStateDto())
            };
        }
    }
}
