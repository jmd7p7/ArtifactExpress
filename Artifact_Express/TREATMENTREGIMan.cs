//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Artifact_Express
{
    using System;
    using System.Collections.Generic;
    
    public partial class TREATMENTREGIMan
    {
        public TREATMENTREGIMan()
        {
            this.TREATMENTREGIMENUSEDs = new HashSet<TREATMENTREGIMENUSED>();
            this.TREATMENTTOOLS = new HashSet<TREATMENTTOOL>();
            this.TREATMENTTECHNIQUEs = new HashSet<TREATMENTTECHNIQUE>();
        }
    
        public int TreatmentRegimenId { get; set; }
        public string TreatementDescription { get; set; }
        public decimal Cost { get; set; }
    
        public virtual ICollection<TREATMENTREGIMENUSED> TREATMENTREGIMENUSEDs { get; set; }
        public virtual ICollection<TREATMENTTOOL> TREATMENTTOOLS { get; set; }
        public virtual ICollection<TREATMENTTECHNIQUE> TREATMENTTECHNIQUEs { get; set; }
    }
}