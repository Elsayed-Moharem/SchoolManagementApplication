//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolApplication.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student_Cources
    {
        public int CRS_ID { get; set; }
        public int ST_ID { get; set; }
        public int ST_Grade { get; set; }
    
        public virtual Cources Cources { get; set; }
        public virtual Student Student { get; set; }
    }
}
