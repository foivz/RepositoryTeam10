//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PIProjektFinal
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipInstitucije
    {
        public TipInstitucije()
        {
            this.Institucija = new HashSet<Institucija>();
        }
    
        public int ID { get; set; }
        public string Naziv { get; set; }
    
        public virtual ICollection<Institucija> Institucija { get; set; }
    }
}
