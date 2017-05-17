using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EtsyClone.ViewModels;

namespace EtsyClone.Models
{
    [Table("Addresses")]
    public class Address
    {
        public int Id { get; internal set; }
        public int UserProfileId { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public bool IsDefault { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public static Address CreateAddress(NewAddressViewModel vm)
        {
            Address newAddress = new Address
            {
                UserProfileId = vm.UserProfileId,
                FullName = vm.FullName,
                Country = vm.Country,
                Street = vm.Street,
                Street2 = vm.Street2,
                City = vm.City,
                ZipCode = vm.ZipCode
            };

            return newAddress;
        }
    }
}
