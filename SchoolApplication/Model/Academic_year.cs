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
    
    public partial class Academic_year
    {
        public int AY_ID { get; set; }
        public string AY_Name { get; set; }
        public int T_ID { get; set; }
        public int ST_ID { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
