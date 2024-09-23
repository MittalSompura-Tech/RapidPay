using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidPayment.Data
{
    public class tblCardDetails
    {
        // public int CardDetailsId { get; set; }
        public int Id { get; set; }
        public string Fname { get; set; } = string.Empty;
        public string Lname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string CardNo { get; set; } = string.Empty;
        public string Cvv { get; set; } = string.Empty;
        public string ValidDateRange { get; set; } = string.Empty;
        public double Balance { get; set; } = 0;

        public ICollection<tblCardTransacationDetails> CardTransacationDetails { get; set; }

    }
}
