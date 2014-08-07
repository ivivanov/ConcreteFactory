using Betonirai.Data.Enums;
using System;

namespace Betonirai.Data
{
    public class Order
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string Item { get; set; }

        public double Quantity { get; set; }

        public Measure Measure { get; set; }

        public string Comment { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public DateTime? DeliveryTime { get; set; }

        //public bool IsConfirmed { get; set; }
    }
}
