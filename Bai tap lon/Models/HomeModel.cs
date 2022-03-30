using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bai_tap_lon.Context;

namespace Bai_tap_lon.Models
{
    public class HomeModel
    {
        public List<Product> ListProduct { get ;  set ; }
        public List<Categorry> ListCategory { get; set; }
    }
}