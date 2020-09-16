using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MSU_Case_LostAndFound.Model;

namespace MSU_Case_LostAndFound.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName="nvarchar(100)")]
        public string firstname { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string lastname { get; set; }
        public virtual ICollection<AnimalsLost> AnimalsLost { get; set; }


    }
}
