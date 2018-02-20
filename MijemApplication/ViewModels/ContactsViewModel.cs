using System.ComponentModel.DataAnnotations;
using System;

namespace MijemApplication.ViewModels
{
    public class ContactsViewModel
    {
        public int ContactId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
              ErrorMessageResourceName = "ContactNameRequired")]
        [Display(Name = "ContactName", ResourceType = typeof(Resources.Resources))]
        public string ContactName { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources.Resources))]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessageResourceType = typeof(Resources.Resources),
                                     ErrorMessageResourceName = "PhoneNumberInvalid")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
              ErrorMessageResourceName = "BirthDateRequired")]
        [Display(Name = "BirthDate", ResourceType = typeof(Resources.Resources))]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [CustomDateValidator(ErrorMessage = "The birthday must be in the past", ErrorMessageResourceType = typeof(Resources.Resources),
                                     ErrorMessageResourceName = "BirthdayInvalid")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resources.Resources))]
        public string Description { get; set; }

        [Display(Name = "ContactType", ResourceType = typeof(Resources.Resources))]
        public string TypeName { get; set; }

        public int ContactType { get; set; } //type Id
        public string FilePath { get; set; }

        public virtual ContactType ContactType1 { get; set; }
    }
}