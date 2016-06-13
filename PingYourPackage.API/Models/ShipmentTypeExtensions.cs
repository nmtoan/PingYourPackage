using PingYourPackage.API.Model.Dtos;
using PingYourPackage.Domain.Entities;

namespace PingYourPackage.API.Models
{
    internal static class ShipmentTypeExtensions
    {
        internal static ShipmentTypeDto ToShipmentTypeDto(this ShipmentType shipmentType)
        {
            return new ShipmentTypeDto
            {
                Key = shipmentType.Key,
                Name = shipmentType.Name,
                Price = shipmentType.Price,
                CreateOn = shipmentType.CreateOn
            };
        }
    }
}
