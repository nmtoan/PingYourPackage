using Autofac;
using Autofac.Integration.WebApi;
using Moq;
using PingYourPackage.Domain.Entities;
using PingYourPackage.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Net.Http;
using PingYourPackage.API.Model.Dtos;

namespace PingYourPackage.API.Test.Integration
{
    [TestFixture]
    public class ShipmentsControllerIntegrationTest
    {
        private static readonly string ApiBaseRequestPath = "api/shipments";

        [TestFixture]
        public class GetShipments
        {
            private static IContainer GetContainer()
            {
                var shipments = GetDummyShipments(new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() });

                Mock<IShipmentService> shipmentSrvMock = new Mock<IShipmentService>();

                shipmentSrvMock
                    .Setup(ss => ss.GetShipments(It.IsAny<int>(), It.IsAny<int>()))
                    .Returns<int, int>((pageIndex, pageSize) => shipments.AsQueryable().ToPaginatedList(pageIndex, pageSize));

                return GetContainerThroughMock(shipmentSrvMock);
            }

            [Test, NullCurrentPrincipal]
            public Task Returns_200_And_Shipments_If_Request_Authorized()
            {
                // Arrange
                var config = IntegrationTestHelper.GetInitialIntegrationTestConfig(GetContainer());

                var request = HttpRequestMessageHelper.ConstructRequest(
                    httpMethod: HttpMethod.Get,
                    uri: string.Format("https://localhost/{0}?page={1}&take={2}", ApiBaseRequestPath, 1, 2),
                    mediaType: "application/json",
                    username: Constants.ValidAdminUserName,
                    password: Constants.ValidAdminPassword);

                return IntegrationTestHelper.TestForPaginatedDtoAsync<ShipmentDto>(
                    config,
                    request,
                    expectedPageIndex: 1,
                    expectedTotalPageCount: 2,
                    expectedCurrentItemsCount: 2,
                    expectedTotalItemsCount: 3,
                    expectedHasNextPageResult: true,
                    expectedHasPreviousPageResult: false);
            }

            
        }

        private static IEnumerable<Shipment> GetDummyShipments(Guid[] keys)
        {
            var shipmentTypeKeys = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };

            for (int i = 0; i < 3; i++)
            {
                yield return new Shipment
                {
                    Key = keys[i],
                    AffiliateKey = Guid.NewGuid(),
                    ShipmentTypeKey = shipmentTypeKeys[i],
                    Price = 12.23M * (i + 1),
                    ReceiverName = string.Format("Receiver {0} Name", i),
                    ReceiverSurname = string.Format("Receiver {0} SurName", i),
                    ReceiverAddress = string.Format("Receiver {0} Address", i),
                    ReceiverCity = string.Format("Receiver {0} City", i),
                    ReceiverCountry = string.Format("Receiver {0} Country", i),
                    ReceiverTelephone = string.Format("Receiver {0} Telephone", i),
                    ReceiverZipCode = "12345",
                    ReceiverMail = "foo@example.com",
                    CreateOn = DateTime.Now,
                    ShipmentType = new ShipmentType
                    {
                        Key = shipmentTypeKeys[i],
                        Name = "Small",
                        Price = 4.19M,
                        CreateOn = DateTime.Now
                    },
                    ShipmentStates = new List<ShipmentState>{
                            new ShipmentState{
                                Key = Guid.NewGuid(),
                                ShipmentKey = keys[i],
                                ShipmentStatus = ShipmentStatus.Ordered
                            },
                            new ShipmentState{
                                Key = Guid.NewGuid(),
                                ShipmentKey = keys[i],
                                ShipmentStatus = ShipmentStatus.Scheduled
                            }
                        }
                };
            }
        }

        private static IContainer GetContainerThroughMock(Mock<IShipmentService> shipmentSrvMock)
        {
            var containerBuilder = GetInitialContainerBuilder();

            containerBuilder
                .Register(c => shipmentSrvMock.Object)
                .As<IShipmentService>()
                .InstancePerApiRequest();

            return containerBuilder.Build();
        }

        private static ContainerBuilder GetInitialContainerBuilder()
        {
            var builder = IntegrationTestHelper.GetEmptyContainerBuilder();

            var mockMemSrv = ServicesMockHelper.GetInitialMembershipServiceMock();

            builder
                .Register(c => mockMemSrv.Object)
                .As<IMembershipService>()
                .InstancePerApiRequest();

            return builder;
        }

    }
}
