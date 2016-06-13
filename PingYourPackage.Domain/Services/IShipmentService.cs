using PingYourPackage.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PingYourPackage.Domain.Services
{
    public interface IShipmentService
    {
        PaginatedList<ShipmentType> GetShipmentTypes(int pageIndex, int pageSize);
        ShipmentType GetShipmentType(Guid key);
        OperationResult<ShipmentType> AddShipmentType(ShipmentType shipmentType);
        ShipmentType UpdateShipmentType(ShipmentType shipmentType);

        PaginatedList<Affiliate> GetAffiliates(int pageIndex, int pageSize);
        Affiliate GetAffiliate(Guid key);
        OperationResult<Affiliate> AddAffiliate(Guid userKey, Affiliate affiliate);
        Affiliate UpdateAffiliate(Affiliate affiliate);

        PaginatedList<Shipment> GetShipments(int pageIndex, int pageSize);
        PaginatedList<Shipment> GetShipments(int pageIndex, int pageSize, Guid affiliateKey);
        Shipment GetShipment(Guid key);
        OperationResult<Shipment> AddShipment(Shipment shipment);
        Shipment UpdateShipment(Shipment shipment);
        OperationResult<Shipment> RemoveShipment(Shipment shipment);

        IEnumerable<ShipmentState> GetShipmentStates(Guid shipmentKey);
        OperationResult<ShipmentState> AddShipmentState(Guid shipmentKey, ShipmentStatus shipmentStatus);

        bool IsAffiliateRelatedToUser(Guid affiliateKey, string username);
    }
}
