using EtsyClone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EtsyClone.ViewModels
{
    public class NewAddressViewModel
    {
        public IEnumerable<SelectListItem> Countries { get; set; }

        [Required]
        public int UserProfileId { get; set; }
         
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Street")]
        public string Street { get; set; }

        [Display(Name = "Apt / Suite / Other")]
        public string Street2 { get; set; }

        [Required]
        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

    }
}
