using Bai_tap_lon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bai_tap_lon.Context
{ 
    [MetadataType(typeof(UserMasterData))]
    public partial class User
    {
       
    }
    [MetadataType(typeof(ProductMaterData))]
    public partial class Product
    {
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
}