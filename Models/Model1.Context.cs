﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace managment.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class schoolmanage : DbContext
    {
        public schoolmanage()
            : base("name=schoolmanage")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<batch> batches { get; set; }
        public virtual DbSet<parent_info> parent_info { get; set; }
        public virtual DbSet<std_add> std_add { get; set; }
        public virtual DbSet<std_info> std_info { get; set; }
        public virtual DbSet<teacher_batch> teacher_batch { get; set; }
        public virtual DbSet<teacher_info> teacher_info { get; set; }
        public virtual DbSet<std_course> std_course { get; set; }
        public virtual DbSet<st_fees> st_fees { get; set; }
        public virtual DbSet<st_subj> st_subj { get; set; }
        public virtual DbSet<std_mat> std_mat { get; set; }
        public virtual DbSet<exam> exams { get; set; }
        public virtual DbSet<exam_result> exam_result { get; set; }
        public virtual DbSet<as_submit> as_submit { get; set; }
        public virtual DbSet<Assingment> Assingments { get; set; }
        public virtual DbSet<notice> notices { get; set; }
    }
}
