using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EtsyClone.Models
{
    [Table("UserProfiles")]
    public class UserProfile
    {
        [Key]
        public string AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        //public virtual ApplicationUser User { get; set; }
    }
}