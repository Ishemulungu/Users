//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Temperature_Recording.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TemperatureRecord
    {
        public int TemperatureRecord1 { get; set; }
        public Nullable<int> UsersID { get; set; }
        public decimal TemperatureReading { get; set; }
        public System.DateTime DateCaptured { get; set; }
    
        public virtual User User { get; set; }
    }
}
