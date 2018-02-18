using System.ComponentModel.DataAnnotations;
using System;
using MijemApplication.Models;
using System.Web.Mvc;
using System.Collections.Generic;

namespace MijemApplication.ViewModels
{
    public class ContactsViewModel
    {
        public int ContactId { get; set; }

        [Required]
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Contact Type")]
        public string TypeDescription { get; set; }
        public string TypeName { get; set; }
        public int ContactTypeId { get; set; }

        public IEnumerable<SelectListItem> Types { get; set; }
    }
}