using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")] // Data annotation to change the label in the view: form
        [Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }
    }
}

