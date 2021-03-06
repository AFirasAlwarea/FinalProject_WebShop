﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_WebShop.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Date of Order")]
        public DateTime OrderDate { get; set; }
        [DisplayName("Customer")]
        public int CustomerId { get; set; }
        public virtual List<OrderRow> OrderRow { get; set; }
    }
}