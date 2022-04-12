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
    [MetadataType(typeof(CategorryMaterData))]
    public partial class Categorry
    {
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
    [MetadataType(typeof(NewsMaterData))]
    public partial class News
    {
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
    [MetadataType(typeof(BrandMaterData))]
    public partial class Brand
    {
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
   
}