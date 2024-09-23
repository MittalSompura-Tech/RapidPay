using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RapidPayment.Data;
using RapidPayment.Model;
using RapidPayment.Model.Repository;
using System.Data.Common;
using System.Diagnostics.Metrics;

namespace RapidPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateCard : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CreateCard(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost, BasicAuthorization]
        public async Task<ActionResult<tblCardDetails>> CreateCarddetails(string firstName, string lastname,string Address,string zipcode, double Balance)
        {
            CardRepository cardresp= new CardRepository(_context);
            var cardNumber = cardresp.GenerateCardNumber();
            var Cvv = cardresp.GenerateCVV();
            var Validaterange = cardresp.GenerateValidateRange();
            tblCardDetails card = new tblCardDetails
            {
                Fname= firstName,
                Lname=lastname,
                Address=Address,
                ZipCode=zipcode,
                CardNo = cardNumber,
                Cvv = Cvv,
                ValidDateRange = Validaterange,
                Balance = Balance
               
            };
            _context.tblCardDetails.Add(card);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllCardDetails), new { id = card.Id }, card);

        }
        [ApiExplorerSettings(IgnoreApi = true)]
        //[NonAction]
        public async Task<ActionResult<IEnumerable<tblCardDetails>>> GetAllCardDetails()
        {
            return await _context.tblCardDetails.ToListAsync();
        }


    }
}


