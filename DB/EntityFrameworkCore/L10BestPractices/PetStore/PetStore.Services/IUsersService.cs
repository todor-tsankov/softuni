using System.Collections.Generic;

using PetStore.Models;
using PetStore.Services.Models;

namespace PetStore.Services
{
    public interface IUsersService
    {
        void AddUser(string firstName, string lastName, string emailAddress);

        User GetUserByFirstName(string firstName);

        User GetUserByLastName(string lastName);

        User GetUserByEmail(string email);

        IEnumerable<UserViewModel> GetUsersWithOrders();
    }
}
