//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace movie
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movie
    {
        public Nullable<int> U_id { get; set; }
        public int M_ID { get; set; }
        public string M_Name { get; set; }
        public string Category { get; set; }
        public string M_describtion { get; set; }
        public int M_Year { get; set; }
    
        public virtual u_User u_User { get; set; }
    }
}
