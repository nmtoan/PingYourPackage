using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingYourPackage.Domain.Entities
{
    public static class ShipmentRepositoryExtensions
    {
        public static IQueryable<Shipment> GetShipmentsByAffiliateKey(this IEntityRepository<Shipment> shipmentRepository,
            Guid affiliateKey)
        {
            return shipmentRepository
                .AllIncluding(x => x.ShipmentType, x => x.ShipmentStates)
                .Where(x => x.AffiliateKey == affiliateKey);
        }
    }
}
