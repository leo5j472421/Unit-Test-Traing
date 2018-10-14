using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EcStore
{
    public class OrderService
    {
        private const string FilePath = @"C:\temp\testOrders.csv";

        public void SyncBookOrders()
        {
            var orders = GetOrders();

            // only get orders of book
            var ordersOfBook = orders.Where(x => x.Type == "Book");

            var bookDao = new BookDao();
            foreach (var order in ordersOfBook)
            {
                bookDao.Insert(order);
            }
        }

        private List<OrderEntity> GetOrders()
        {
            // parse csv file to get orders
            var result = new List<OrderEntity>();

            // directly depend on File I/O
            using (StreamReader sr = new StreamReader(FilePath, Encoding.UTF8))
            {
                int rowCount = 0;

                while (sr.Peek() > -1)
                {
                    rowCount++;

                    var content = sr.ReadLine();

                    // Skip CSV header line
                    if (rowCount > 1)
                    {
                        string[] line = content.Trim().Split(',');

                        result.Add(Mapping(line));
                    }
                }
            }

            return result;
        }

        private OrderEntity Mapping(string[] line)
        {
            var result = new OrderEntity
            {
                ProductName = line[0],
                Type = line[1],
                Price = Convert.ToInt32(line[2]),
                CustomerName = line[3]
            };

            return result;
        }
    }
}