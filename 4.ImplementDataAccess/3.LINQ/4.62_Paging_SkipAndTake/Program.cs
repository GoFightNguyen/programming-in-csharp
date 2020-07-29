using System.Linq;
using System.Collections.Generic;
using System;

namespace _4._62_Paging_SkipAndTake
{
    class Program
    {
        static void Main(string[] args)
        {
            bool wereThereOrders;
            int pageIndex = 1;
            int pageSize = 3;

            do
            {
                var orders = GetOrders(pageIndex, pageSize);
                if (orders.Any())
                {
                    wereThereOrders = true;
                    Console.WriteLine(string.Join(", ", orders));
                }
                else
                    wereThereOrders = false;
                pageIndex++;

            } while (wereThereOrders);

            Console.ReadLine();
        }

        private static IEnumerable<int> GetOrders(int pageIndex, int pageSize)
        {
            var orders = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            return orders.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}
