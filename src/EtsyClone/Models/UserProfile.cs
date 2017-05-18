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
        public int Id { get; internal set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }

        public string CombineName()
        {
            return FirstName + " " + LastName;
        }

        public string PosessiveName(string input)
        {
            return input + "'s";
        }

        //public IEnumerable<Address> GetAddresses()
        //{
        //    IAddressRepository addressRepo = new IAddressRepository();
        //    var Addresses = IAddressRepository.Addresses
        //    return Addresses;
        //}
    }
}