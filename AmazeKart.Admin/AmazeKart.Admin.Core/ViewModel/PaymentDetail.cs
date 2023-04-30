﻿namespace AmazeKart.Admin.Core.ViewModel
{
    public class PaymentDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public Order Order { get; set; }
    }
}