﻿using System.Runtime.Serialization;

namespace AmazeKart.Admin.Core.ObjectModel
{
    [DataContract]
    public partial class OrderDetail
    {
        public OrderDetail()
        {
        }

        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public decimal Discount { get; set; }
        [DataMember]
        public decimal OrderAmount { get; set; }
    }
}