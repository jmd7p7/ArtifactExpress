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
    
    public partial class TIMEPERIOD
    {
        public TIMEPERIOD()
        {
            this.ARTIFACTs = new HashSet<ARTIFACT>();
            this.COLLECTIONs = new HashSet<COLLECTION>();
        }
    
        public int TimePeriodId { get; set; }
        public string TimePeriodName { get; set; }
        public Nullable<int> TimePeriodBeginningYear { get; set; }
        public Nullable<int> TimePeriodEndingYear { get; set; }
    
        public virtual ICollection<ARTIFACT> ARTIFACTs { get; set; }
        public virtual ICollection<COLLECTION> COLLECTIONs { get; set; }
    }
}