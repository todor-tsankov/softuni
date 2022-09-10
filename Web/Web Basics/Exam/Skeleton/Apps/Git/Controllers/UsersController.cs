﻿using System.ComponentModel.DataAnnotations;

using Git.Services;
using Git.ViewModels;
using Git.ViewModels.Users;

using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Error("Already logged in.");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (this.IsUserSignedIn())
            {
                return this.Error("Already logged in.");
            }

            var userId = this.usersService.GetUserId(username, password);

            if (userId == null)
            {
                return this.Error("Invalid username or password!");
            }

            this.SignIn(userId);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Error("Already logged in.");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UserInputModel input)
        {
            if (this.IsUserSignedIn())
            {
                return this.Error("Already logged in.");
            }

            if (string.IsNullOrWhiteSpace(input.Username)
                || input.Username.Length < 5
                || input.Username.Length > 20)
            {
                return this.Error("Username must be between 5 and 20 characters long.");
            }

            if (string.IsNullOrWhiteSpace(input.Email)
                || !new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.Error("Invalid email.");
            }

            if (string.IsNullOrWhiteSpace(input.Password)
                || input.Password.Length < 6
                || input.Password.Length > 20)
            {
                return this.Error("Password must be between 6 and 20 characters long.");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Passwords don't match.");
            }

            if (!this.usersService.IsUsernameAvailable(input.Username))
            {
                return this.Error("The given Username is already taken.");
            }

            if (!this.usersService.IsEmailAvailable(input.Email))
            {
                return this.Error("The given Email is already taken.");
            }

            this.usersService.CreateUser(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("Already logged out.");
            }

            this.SignOut();

            return this.Redirect("/");
        }

    }
}
