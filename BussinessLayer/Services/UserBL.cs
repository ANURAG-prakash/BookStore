using BussinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class UserBL : IUserBL

    {
        readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public User Authenticate(string Email, string Password)
        {
            try
            {
                return userRL.Authenticate(Email, Password);
            }
            catch (Exception a)
            {
                throw a;
            }
        }
    }
}
