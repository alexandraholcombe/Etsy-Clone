using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EtsyClone.Models;

namespace EtsyClone.ViewModels
{
    public class AddressesViewModel
    {
        public UserProfile UserProfile { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
