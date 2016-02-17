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
    
    public partial class COLLECTION
    {
        public COLLECTION()
        {
            this.EXHIBITs = new HashSet<EXHIBIT>();
            this.ARTIFACTs = new HashSet<ARTIFACT>();
        }
    
        public int CollectionID { get; set; }
        public string CollectionName { get; set; }
        public string CollectionDescription { get; set; }
        public int CollectionTimePeriod { get; set; }
        public int CollectionCountryOfOrigin { get; set; }
    
        public virtual COUNTRY COUNTRY { get; set; }
        public virtual ICollection<EXHIBIT> EXHIBITs { get; set; }
        public virtual TIMEPERIOD TIMEPERIOD { get; set; }
        public virtual ICollection<ARTIFACT> ARTIFACTs { get; set; }
    }
}