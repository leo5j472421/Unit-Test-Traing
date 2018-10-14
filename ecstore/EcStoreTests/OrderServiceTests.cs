using System;
using EcStore;
using NUnit.Framework;

namespace EcStoreTests
{
    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void SyncBookOrdersTest_two_books_orders_of_three_orders()
        {
            new OrderService().SyncBookOrders();
        }
    }
}