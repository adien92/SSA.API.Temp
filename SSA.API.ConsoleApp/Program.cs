using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSA.API.ConsoleApp
{
    class Program
    {
        public static readonly Queue<OrderInfo> queue = new Queue<OrderInfo>();
        public static object obj = new object();
        static void Main(string[] args)
        {
            #region 模仿淘宝处理订单问题
            //订单进入队列等待
            Task OrderTask = new Task(CreateOrder);
            OrderTask.Start();

            //开启线程处理订单
            Task taskDeal = new Task(DealOrder);
            taskDeal.Start();
            Console.WriteLine("hello");
            #endregion

            Console.ReadKey();
        }
        public static void CreateOrder()
        {
            for (int i = 1; i < 50; i++)
            {
                Thread.Sleep(300);
                lock (obj)
                {
                    OrderInfo order = new OrderInfo();
                    order.OrderId = i;
                    order.ProductId = 2800 + i;
                    order.Price = 888 + i;
                    order.Remarks = "quick send goods";
                    queue.Enqueue(order);
                    Console.WriteLine("添加了一条订单" + i);
                }
            }
        }

        public static int flag = 0;
        public static void DealOrder()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (queue.Count > 5)
                {
                    lock (obj)
                    {
                        if (queue.Count > 5)
                        {
                            var count = queue.Count;
                            for (int i = 0; i < count; i++)
                            {
                                OrderInfo order = queue.Dequeue();
                                Console.WriteLine("处理==>订单号{0}；商品：{1}价格：{2}", order.OrderId, order.ProductId, order.Price);
                            }
                           
                        }
                    }
                }
                else
                {
                    Thread.Sleep(2000);
                    flag++;
                    if (flag > 10) { Console.WriteLine("All Over"); break; }
                    lock (obj)
                    {
                        if (queue.Count <= 0)
                        {
                            Console.WriteLine("订单处理完成，等待中。。。");
                        }
                    }
                }
            }

        }
    }

    public struct OrderInfo
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Decimal Price { get; set; }
        public string Remarks { get; set; }
    }
}
