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
    
    public partial class ARTIFACT
    {
        public ARTIFACT()
        {
            this.ARTIFACTPRESERVATIONs = new HashSet<ARTIFACTPRESERVATION>();
            this.STORAGEREQUIREMENTs = new HashSet<STORAGEREQUIREMENT>();
            this.PHOTOGRAPHs = new HashSet<PHOTOGRAPH>();
        }
    
        public int ArtifactId { get; set; }
        public string ArtifactName { get; set; }
        public string ArtifactDescriptionSummary { get; set; }
        public decimal AppraisedValue { get; set; }
        public decimal InsuredValue { get; set; }
        public int OfTimePeriod { get; set; }
        public int ArtifactType { get; set; }
        public int CountryOfOrigin { get; set; }
    
        public virtual ARTIFACTTYPE ARTIFACTTYPE1 { get; set; }
        public virtual COUNTRY COUNTRY { get; set; }
        public virtual TIMEPERIOD TIMEPERIOD { get; set; }
        public virtual ARTIST ARTIST { get; set; }
        public virtual ICollection<ARTIFACTPRESERVATION> ARTIFACTPRESERVATIONs { get; set; }
        public virtual ICollection<STORAGEREQUIREMENT> STORAGEREQUIREMENTs { get; set; }
        public virtual COLLECTION COLLECTION { get; set; }
        public virtual LOCATION LOCATION { get; set; }
        public virtual ICollection<PHOTOGRAPH> PHOTOGRAPHs { get; set; }
    }
}
