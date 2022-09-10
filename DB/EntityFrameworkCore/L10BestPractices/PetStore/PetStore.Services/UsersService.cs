using System;
using System.Linq;
using System.Collections.Generic;

using PetStore.Data;
using PetStore.Models;
using PetStore.Services.Models;

namespace PetStore.Services
{
    public class UsersService : IUsersService
    {
        private PetStoreDbContext db;

        public UsersService()
        {
            db = new PetStoreDbContext();
        }

        public void AddUser(string firstName, string lastName, string emailAddress)
        {
            this.StringCheck(firstName, nameof(User), nameof(firstName));
            this.StringCheck(lastName, nameof(User), nameof(lastName));
            this.StringCheck(emailAddress, nameof(User), nameof(emailAddress));

            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public User GetUserByFirstName(string firstName)
        {
            return this.db.Users
                .FirstOrDefault(x => x.FirstName == firstName);
        }

        public User GetUserByLastName(string lastName)
        {
            return this.db.Users
                .FirstOrDefault(x => x.LastName == lastName);
        }
        public User GetUserByEmail(string email)
        {
            return this.db.Users
                .FirstOrDefault(x => x.EmailAddress == email);
        }

        public IEnumerable<UserViewModel> GetUsersWithOrders()
        {
            return this.db.Users
                .Where(x => x.Orders.Any())
                .Select(x => new UserViewModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    EmailAddress = x.EmailAddress,
                    Orders = x.Orders
                })
                .ToArray();
        }

        private void StringCheck(string name, string className, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                var message = $"{className} {parameterName} cannot be null or whitespace!!!";

                throw new ArgumentException(message);
            }
        }
    }
}
