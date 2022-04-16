using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai_tap_lon.Models
{
    public class OrderDetailMaterData
    {
        public int Id { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> Price { get; set; }
    }
}