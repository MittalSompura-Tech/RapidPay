using System.ComponentModel.DataAnnotations;

namespace RapidPayment.Data
{
    public class UserDetails
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        [RegularExpression(@"^\d{5,}$", ErrorMessage = "The ZipCode must contain at least 5 digits.")]
        public string ZipCode { get; set; } = string.Empty;
        public string Dob { get; set; } = string.Empty;
    }
}
