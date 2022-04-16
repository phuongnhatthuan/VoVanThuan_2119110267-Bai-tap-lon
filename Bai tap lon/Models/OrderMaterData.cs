using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai_tap_lon.Models
{
    public class OrderMaterData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<long> CustomerID { get; set; }
        public string ShipName { get; set; }
        public string ShipMobile { get; set; }
        public string ShipEmail { get; set; }
        public string ShipAddress { get; set; }
    }
}