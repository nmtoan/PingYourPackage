using PingYourPackage.API.Model.Dtos;
using PingYourPackage.Domain.Entities;

namespace PingYourPackage.API.Models
{
    internal static class ShipmentStateExtensions
    {
        internal static ShipmentStateDto ToShipmentStateDto(this ShipmentState shipmentState)
        {
            return new ShipmentStateDto
            {
                Key = shipmentState.Key,
                ShipmentKey = shipmentState.ShipmentKey,
                ShipmentStatus = shipmentState.ShipmentStatus.ToString(),
                CreateOn = shipmentState.CreateOn
            };
        }
    }
}
