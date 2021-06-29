﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")] // Data annotation to change the label in the view: form
        public DateTime? Birthdate { get; set; }
    }
}
