using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bai_tap_lon.Models
{
    public class NewsMaterData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên bài viết")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Hình đại diện")]
        public string Avartar { get; set; }
        [Display(Name = "Phải có mô tả ngắn")]
        public string ShotDes { get; set; }
        [Display(Name = "Phải có mô tả dài")]
        public string FullDescription { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<System.DateTime> CreateOnUtc { get; set; }
        public Nullable<System.DateTime> UpdateOnUtc { get; set; }
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
}