using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EtsyClone.Models;

namespace EtsyClone.ViewModels
{
    public class ProfileViewModel
    {
        public ApplicationUser Account { get; set; }
        public UserProfile Profile { get; set; }
    }
}
