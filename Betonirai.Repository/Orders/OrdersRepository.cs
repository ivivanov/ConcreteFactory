using Betonirai.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Betonirai.Repository.Orders
{
    public class OrdersRepository : IOrdersRepository
    {
        public IQueryable<Order> GetAllOrders()
        {
            OrdersDbContext db = new OrdersDbContext();
            return db.Orders.AsQueryable();
        }

        public Order GetOrder(int id)
        {
            OrdersDbContext db = new OrdersDbContext();

            return db.Orders.Find(id);
        }

        public bool Insert(Order order)
        {
            try
            {
                OrdersDbContext db = new OrdersDbContext();

                db.Orders.Add(order);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Order updatedOrder)
        {
            try
            {
                OrdersDbContext db = new OrdersDbContext();
                Order originalOrder = db.Orders.Find(updatedOrder.Id);
                db.Entry(originalOrder).CurrentValues.SetValues(updatedOrder);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Order order = this.GetOrder(id);
                OrdersDbContext db = new OrdersDbContext();

                db.Orders.Remove(order);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
