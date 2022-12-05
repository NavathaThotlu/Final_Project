using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMVcApp.Models
{
    public class search
    {
        public int q_id { get; set; }
        public string q_text { get; set; }
        public string QA { get; set; }
        public string QB { get; set; }
        public string QC { get; set; }
        public string QD { get; set; }
        public string QcorrectAns { get; set; }
        public string cat_name { get; set; }

        public int Car_id { get; set; }
    }
}