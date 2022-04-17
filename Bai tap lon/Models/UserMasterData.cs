using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bai_tap_lon.Models
{
    public class UserMasterData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [Display(Name = "Tên ")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [Display(Name = "Username ")]
        public string Email { get; set; }
        [Display(Name = "Password ")]
        public string Password { get; set; }
        public Nullable<bool> IsAdmin { get; set; }
    }
}