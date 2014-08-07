using Betonirai.Data;
using Betonirai.Repository.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace Betonirai.WebApi.Controllers
{
    public class OrdersController : BaseApiController
    {
        private IOrdersRepository ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public IOrdersRepository OrdersRepository
        {
            get
            {
                return this.ordersRepository;
            }
        }

        [HttpGet]
        public List<Order> Get()
        {
            return OrdersRepository.GetAllOrders().ToList();
        }

        [HttpGet]
        public Order Get(int id)
        {
            return OrdersRepository.GetOrder(id);
        }

        /*{"Id":3,"Address":"Sofia, 1","Item":"Meton","Quantity":1.0,"Measure":1,
            "Comment":"Ela tuka u kvartala",
            "Email":"asd@asd.sd",
            "Phone":"+12423",
            "DeliveryDate":"2014-12-12T00:00:00",
            "DeliveryTime":"2000-01-01T15:30:00"}*/
        [HttpPost]
        public HttpResponseMessage Add(Order order)
        {
            if (OrdersRepository.Insert(order))
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "missing required order fileds" };
        }

        [HttpPut]
        public HttpResponseMessage Update(int id, [System.Web.Http.FromBody]Order order)
        {
            if (OrdersRepository.Update(order))
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "failed to update order" };
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            if (OrdersRepository.Delete(id))
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "failed to delete order (invalid id)" };
        }
    }
}
