using Betonirai.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betonirai.Repository.Orders
{
    public interface IOrdersRepository
    {
        IQueryable<Order> GetAllOrders();
        Order GetOrder(int id);
        bool Insert(Order order);
        bool Update(Order updatedOrder);
        bool Delete(int id);
    }
}
