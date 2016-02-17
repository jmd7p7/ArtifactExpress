using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Artifact_Express.Models
{
    public class ArtifactInLocation
    {
        [Key]
        public string  Artifact { get; set; }
    }
}