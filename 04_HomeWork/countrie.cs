//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _04_HomeWork
{
    using System;
    using System.Collections.Generic;
    
    public partial class countrie
    {
        public countrie()
        {
            this.languages = new HashSet<language>();
        }
    
        public int country_id { get; set; }
        public string country { get; set; }
    
        public virtual ICollection<language> languages { get; set; }
    }
}
