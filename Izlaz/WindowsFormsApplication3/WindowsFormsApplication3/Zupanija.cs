//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApplication3
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zupanija
    {
        public Zupanija()
        {
            this.Mjesto = new HashSet<Mjesto>();
        }
    
        public int ID { get; set; }
        public string Naziv { get; set; }
    
        public virtual ICollection<Mjesto> Mjesto { get; set; }
    }
}
