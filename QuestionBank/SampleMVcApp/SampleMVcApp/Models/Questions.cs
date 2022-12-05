using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SampleMVcApp.Models
{
    public class Questions
    {
       [Key]
        public int q_id { get; set; }
        public string q_text { get; set; }
        public string QA { get; set; }
        public string QB { get; set; }
        public string QC { get; set; }
        public string QD { get; set; }
        public string QcorrectAns { get; set; }
        [NotMapped]
        public int Car_id { get; set; }

        

        public virtual tbl_category Tbl_Category { get; set; }

    }
}