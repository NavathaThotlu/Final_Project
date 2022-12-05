using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleMVcApp.Models
{
    public partial class category
    {
       
        public int cat_id { get; set; }
        
        public string cat_name { get; set; }
        public Nullable<int> cat_ad_id { get; set; }
        //public virtual tbl_admin tbl_admin {get;set;}
    }
}