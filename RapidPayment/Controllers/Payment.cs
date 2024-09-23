using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RapidPayment.Data;
using RapidPayment.Model;
using RapidPayment.Model.Repository;
using System.Net;
using System.Reflection.Emit;
using System.Transactions;

namespace RapidPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Payment : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Payment(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost, BasicAuthorization]
        public string UpdatePayment(string firstname, string lastname, string cardno, string cvv, string validaterange, string category, double Payment_Amount)

        {
            try
            {
                CardRepository card = new CardRepository(_context);
                tblCardDetails? validcard = new tblCardDetails();
                validcard = card.ValidateCard(firstname, lastname, cardno, cvv, validaterange);
                if (validcard == null)
                {
                    return "Card does not exist";
                }
                double newbalance;
                double paymentfee = RapidPayment.Model.UFEServiceSinglton.GetInstance();
                if (validcard.Balance >= paymentfee + Payment_Amount)
                {
                    newbalance = validcard.Balance - (paymentfee + Payment_Amount);
                }
                else
                {
                    return "Insufficient Funds";
                }
                validcard.Balance = Math.Round(newbalance, 2);
                _context.tblCardDetails.Update(validcard);

                _context.SaveChangesAsync();
                return "Paymente successful";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
            
    }
 }
