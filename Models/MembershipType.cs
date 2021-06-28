using System;
namespace MovieRental.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationMonths { get; set; }
        public byte DiscountRate { get; set; }
        public string Name { get; set; }
    }
}
