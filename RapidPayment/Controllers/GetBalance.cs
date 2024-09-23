using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RapidPayment.Data;
using RapidPayment.Model;
using RapidPayment.Model.Repository;
using System.Net;
using System.Reflection.Emit;

namespace RapidPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetBalance : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetBalance(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost, BasicAuthorization]
        public string GetBalanceDetails(string firstname, string lastname, string cardno, string cvv, string validaterange)
        {
            CardRepository card = new CardRepository(_context);
            tblCardDetails? validcard = new tblCardDetails();
            validcard = card.ValidateCard(firstname, lastname, cardno, cvv, validaterange);
            if (validcard == null)
            {
                return "Card does not exist";
            }
           return validcard.Balance.ToString();

        }
               
    }
}


