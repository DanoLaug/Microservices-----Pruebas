﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order.Domain;
using static Order.Common.Enums;

namespace Order.Service.Queries.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public OrderPayment PaymentType { get; set; }
        public int ClientId { get; set; }
        public ICollection<OrderDetail> Items { get; set; } = new List<OrderDetail>();
        public DateTime CreatedAt { get; set; }
        public decimal Total { get; set; }
    }
}
