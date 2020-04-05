using System.ComponentModel.DataAnnotations;

namespace EHI.WebApp.Models {
    public class PatientContact {
        [Key]
        public int ContactId { get; set; }
        [Required(ErrorMessage = "First Name can not be left blank.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name can not be left blank.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Phone number can not be left blank.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "The Phone Number field is not a valid phone number.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email address can not be left blank.")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        public bool Status { get; set; }
    }
}