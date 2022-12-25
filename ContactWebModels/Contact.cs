using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWebModels
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="First Name is required")]
        [Display(Name ="First Name")]
        [StringLength(ContactMangerConstants.MAX_FIRST_NAME_LENGTH)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        [StringLength(ContactMangerConstants.MAX_LAST_NAME_LENGTH)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(ContactMangerConstants.MAX_EMAIL_LENGTH)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        [StringLength(ContactMangerConstants.MAX_EMAIL_LENGTH)]
        public string EmailConfirmed { get; set; }

        [Display(Name = "Mobile Phone")]
        [Required(ErrorMessage = "Mobile Phone number is required")]
        [StringLength(ContactMangerConstants.MAX_PHONE_LENGTH)]
        [Phone(ErrorMessage = "Invalid Phone number")]
        public string PhonePrimary { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(ContactMangerConstants.MAX_PHONE_LENGTH)]
        [Phone(ErrorMessage = "Invalid Phone number")]
        public string PhoneSecondary { get; set; }

        [Display(Name = "Birthday Date")]
        [Required(ErrorMessage = "Birthday is required")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Display(Name = "Street Address Line 1")]
        [Required(ErrorMessage = "Street Address is required")]
        [StringLength(ContactMangerConstants.MAX_STREET_ADDRESS_LENGTH)]
        public string StreetAddress1 { get; set; }

        [Display(Name = "Street Address Line 2")]
        [Required(ErrorMessage = "Street Address is required")]
        [StringLength(ContactMangerConstants.MAX_STREET_ADDRESS_LENGTH)]
        public string StreetAddress2 { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(ContactMangerConstants.MAX_CITY_LENGTH)]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required")]
        public int StateId { get; set; }

        public virtual State State { get; set; }

        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "ZipCode is required")]
        [StringLength(ContactMangerConstants.MAX_ZIP_CODE_LENGTH, MinimumLength = ContactMangerConstants.MIN_ZIP_CODE_LENGTH)]
        [RegularExpression("(^\\d{5}(-\\d{4})?$)|{^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}$)", ErrorMessage ="Zip Code is invalid.")] //US or Canada
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "The User ID is required to map the contact to a user correctly")]
        public int UserId { get; set; }

        [Display(Name = "Full Name")]
        public string FriendlyName => $"{FirstName} {LastName}";
        [Display(Name = "Full Address")]
        public string FriendlyAddress => 
            State is null ? 
            "" : 
            string.IsNullOrWhiteSpace(StreetAddress1) ? 
            $"{City}, {State.Abbreviation}, {ZipCode}" :
            string.IsNullOrWhiteSpace(StreetAddress2) ? 
            $"{StreetAddress2}, {City}, {State.Abbreviation}, {ZipCode}":
            $"{StreetAddress1} - {StreetAddress2}, {City}, {State.Abbreviation}, {ZipCode}";
    }
}
