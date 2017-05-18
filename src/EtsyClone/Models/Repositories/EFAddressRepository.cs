using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EtsyClone.Models
{
    public class EFAddressRepository : IAddressRepository
    {
        EtsyContext db = new EtsyContext();

        public IQueryable<Address> Addresses
        {           
                get { return db.Addresses; }            
        }

        public Address Save(Address address)
        {
            db.Addresses.Add(address);
            db.SaveChanges();
            return address;
        }

        public Address Edit(Address address)
        {
            db.Entry(address).State = EntityState.Modified;
            db.SaveChanges();
            return address;
        }

        public void Remove(Address address)
        {
            db.Addresses.Remove(address);
            db.SaveChanges();
        }
    }
}