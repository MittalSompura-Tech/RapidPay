using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
namespace RapidPayment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       // public DbSet<UserDetails> userDetails { get; set; }
        public DbSet<tblCardDetails> tblCardDetails { get; set; }
        public DbSet<tblCardTransacationDetails> cardTransacationDetails { get; set; }
        // public DbSet<UFEService> uFEServices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<tblCardTransacationDetails>()
            //    .HasOne(p => p.Id)
            //    .WithMany(b => b.cardTransacationDetails)
            //    .HasForeignKey(p => p.Transid);

                //modelBuilder.Entity<tblCardDetails>()
                //.HasMany(c => c.CardTransacationDetails)
                //.WithOptional()
                //.Map(m => m.MapKey("Id"));
        }
       
    }

   
}
