using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Artifact_Express.Models
{
    public class AuthenticationStatus
    {
        [Key]
        [Column(Order = 1)]
        [Display(Name="Authentication Status")]
        public string isAuthenticated { get; set; }
        [Key]
        [Column(Order = 2)]
        public string artifactName { get; set; }
    }
}