using System;
using System.ComponentModel.DataAnnotations;
using MovieRental.Models;

namespace MovieRental.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToLetter { get; set; }

        public byte MembershipTypeId { get; set; }

        [Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }
    }
}
