﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SampleMVcApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class COMPANYEntities : DbContext
    {
        public COMPANYEntities()
            : base("name=COMPANYEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<tbl_admin> tbl_admin { get; set; }
        public virtual DbSet<tbl_category> tbl_category { get; set; }
        public virtual DbSet<tbl_questions> tbl_questions { get; set; }
    
        public virtual ObjectResult<Allquestions_Result> Allquestions()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Allquestions_Result>("Allquestions");
        }
    
        public virtual ObjectResult<Allquestions_Result> fun_Allquestions()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Allquestions_Result>("fun_Allquestions");
        }
    
        public virtual ObjectResult<serach_Result> serach(string category)
        {
            var categoryParameter = category != null ?
                new ObjectParameter("category", category) :
                new ObjectParameter("category", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<serach_Result>("serach", categoryParameter);
        }
    
        public virtual ObjectResult<serach_Result> search(string category)
        {
            var categoryParameter = category != null ?
                new ObjectParameter("category", category) :
                new ObjectParameter("category", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<serach_Result>("search", categoryParameter);
        }
    }
}