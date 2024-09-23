using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
namespace RapidPayment.Data
{
    public class tblCardTransacationDetails
    {
        public  int TransId { get; set; }
        public DateOnly Transddate { get;set; }
        public string Category { get; set; }
        public double payment { get; set; }
        public double paymentfees { get; set; }

        public int Id { get; set; } // Foreign Key
        public tblCardDetails CardDetails { get; set; } // Navigation Property
        
    }
}
