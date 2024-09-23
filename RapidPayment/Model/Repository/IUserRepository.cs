using System.Net;
using RapidPayment.Data;

namespace RapidPayment.Model.Repository
{
    public interface IUserRepository
    {

        Task<UserDetails> AddUser(UserDetails user);
        int ValidateUser(string FirstName, string LastName);
        //Task<UserDetails?> ValidateUser(string FirstName, string LastName);
        Task<UserDetails> GetUserById(int id);

    }


}
