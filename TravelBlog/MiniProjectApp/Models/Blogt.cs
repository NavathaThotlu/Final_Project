//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiniProjectApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Blogt
    {
        public int BlogId { get; set; }
        public int Userid { get; set; }
        public string Title { get; set; }
        public System.DateTime TravelDate { get; set; }
        public string Details { get; set; }
        public string Images { get; set; }
        public int ratings { get; set; }
    
        public virtual UserT UserT { get; set; }
    }
}
