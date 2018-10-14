using System;
using System.Collections.Generic;
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
            var orderservice = new FakeOrderService();
            orderservice.SyncBookOrders();
            Assert.AreEqual(2,orderservice.GetOrderTimes());
        }
    }

    class FakeOrderService : OrderService
    {

        private int _orderTimes = 0;

        public int GetOrderTimes()
        {
            return _orderTimes;
        }

        protected override void InsertOrder(BookDao bookDao, OrderEntity order)
        {
            _orderTimes++;
        }
        protected override List<OrderEntity> GetOrders()
        {
            return new List<OrderEntity>()
            {
                new OrderEntity()
                {
                    Type = "Book"
                },
                new OrderEntity()
                {
                    Type = "Book"
                },
                new OrderEntity()
                {
                    Type = "Iphone"
                }
            };
        }
    }
}