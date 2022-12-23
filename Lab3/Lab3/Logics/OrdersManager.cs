using Lab3.Models;

namespace Lab3.Logics
{
    public class OrdersManager
    {
        public List<Order> GetOrders(int OrderId = 0)
        {
            using (var context = new NorthwindContext())
            {
                context.Orders.ToList();
                if ( OrderId == 0)
                {
                    return context.Orders.ToList(); ;
                }
                else
                {
                    return context.Orders.Where(x => x.OrderId == OrderId).ToList();
                }
            }
        }

        public Order GetOrder(int OrderId)
        {
            using (var context = new NorthwindContext())
            {
                context.Orders.ToList();
                return context.Orders.FirstOrDefault(x => x.OrderId == OrderId);
            }
        }

        public DateTime maxOrderDate()
        {
            var db = new NorthwindContext();
            var maxDate = (from maxod in db.Orders select maxod).Max(maxod => maxod.OrderDate);
            DateTime max = Convert.ToDateTime(maxDate);
            return max;
        }
        public DateTime minOrderDate()
        {
            var db = new NorthwindContext();
            var minDate = (from minod in db.Orders select minod).Min(minod => minod.OrderDate);
            DateTime min = Convert.ToDateTime(minDate);
            return min;
        }

        internal void EditOrder(Order order)
        {
            using (var context = new NorthwindContext())
            {
                Order or = context.Orders.FirstOrDefault(x => x.OrderId == order.OrderId);
                if (or != null)
                {
                    or.EmployeeId = order.EmployeeId;
                    or.CustomerId = order.CustomerId;
                    or.OrderDate = order.OrderDate;
                    or.Freight = order.Freight;
                }
                context.SaveChanges();
            }
        }
        public void DeleteOrder(int OrderId)
        {
            using (var context = new NorthwindContext())
            {
                Order or = context.Orders.FirstOrDefault(x => x.OrderId == OrderId);
                if (or != null)
                {
                    List<OrderDetail> orderDetails =
                        context.OrderDetails.Where(x => x.OrderId == or.OrderId)
                        .ToList();
                    context.OrderDetails.RemoveRange(orderDetails);
                    context.Orders.Remove(or);
                }
                context.SaveChanges();
            }
        }
    }
}
