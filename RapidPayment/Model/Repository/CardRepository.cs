using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore.SqlServer;
using RapidPayment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace RapidPayment.Model.Repository
{

    public class CardRepository
    {
        private readonly ApplicationDbContext _context;

        public CardRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public  string randomNoGenreation(int minvalue, int maxvalue)
        {
            Random rnd = new Random();
            int temp = rnd.Next(minvalue, maxvalue);
            return temp.ToString();
        }
        public  string GenerateCardNumber()
        {
            return $"{randomNoGenreation(3005, 4999)} {randomNoGenreation(1000, 9999)} {randomNoGenreation(1000, 9999)} {randomNoGenreation(1000, 9999)}";
        }
        public  string GenerateCVV()
        {
            return randomNoGenreation(100, 999).ToString();
        }
        public  string GenerateValidateRange()
        {
            Random rnd = new Random();
            string strformat = "";
            int num1 = rnd.Next(01, 12);
            int num2 = rnd.Next((DateTime.Parse(DateTime.Now.ToString()).Year), (DateTime.Parse(DateTime.Now.ToString()).Year + 2));
            if (num1 > 10) strformat = "0" + num1.ToString();
            else strformat = num1.ToString();
            var daterange = $"{strformat}/{num2}";
            return daterange.ToString();
        }
        public  tblCardDetails? ValidateCard(string firstname,string lastname,string cardno, string cvv, string validaterange)
        {
           // var result = 
              return   _context.tblCardDetails.Where(u => u.Fname == firstname && u.Lname == lastname && u.CardNo == cardno && u.Cvv == cvv && u.ValidDateRange == validaterange).FirstOrDefault();
           // return result;
        }
        
    }
}
