using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtsyClone.Models
    public interface IAddressRepository
    {
        IQueryable<Address> Addresses { get; }
        Address Save(Address address);
        Address Edit(Address address);
        void Remove(Address address);
    }
}
