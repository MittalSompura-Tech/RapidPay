using System.ComponentModel;
using System.Diagnostics.Metrics;
using RapidPayment.Data;

namespace RapidPayment.Model.Repository
{
    public class UserRepository : IUserRepository
    {
        private List<UserDetails> users = new List<UserDetails>
            {
               // Initial set of users.just for checking
                new UserDetails { UserId = 1, FirstName = "admin", LastName = "admin",Address="2345, saginaw st",City="saginaw",ZipCode="45678",Dob="10/09/2001" }             
            };

        // Adds a new user if no duplicate ID is found.
        public async Task<UserDetails> AddUser(UserDetails user)
        {
            await Task.Delay(100); // Simulates a delay.
            if (users.Any(u => u.UserId == user.UserId))
            {
                throw new Exception("User already exists with the given ID."); // Exception if user with same ID exists.
            }
            users.Add(user); // Adds the new user to the list.
            return user; // Returns the added user.
        }

        public int ValidateUser(string FirstName, string LastName)
        {
            var result = users.Where(u => u.FirstName == FirstName && u.LastName == LastName).Select(u => u.UserId).FirstOrDefault();
            return result;
        }


        // Retrieves a user by ID.
        public async Task<UserDetails> GetUserById(int UserId)
           {
            await Task.Delay(100); // Simulates a delay.
            return users.FirstOrDefault(predicate: u => u.UserId == UserId); // Returns the user if found.
          }

    }
}
