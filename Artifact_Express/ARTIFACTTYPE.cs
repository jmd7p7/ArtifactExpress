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
    
    public partial class ARTIFACTTYPE
    {
        public ARTIFACTTYPE()
        {
            this.ARTIFACTs = new HashSet<ARTIFACT>();
        }
    
        public int ArtifactTypeId { get; set; }
        public string Type { get; set; }
    
        public virtual ICollection<ARTIFACT> ARTIFACTs { get; set; }
    }
}
