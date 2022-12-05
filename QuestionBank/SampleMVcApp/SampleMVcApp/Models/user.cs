using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleMVcApp.Models
{
    public partial class user
    {
        public int ad_id { get; set; } 
        
        [Display(Name ="User Name")]
        //[Required(ErrorMessage ="*")]
        public string ad_name { get; set; }
        
        [Display(Name = "User password")]
        //[Required(ErrorMessage = "*")]
        public string ad_password { get; set; }
    }
}