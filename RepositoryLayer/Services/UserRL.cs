using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
   public  class UserRL 

    {
        private readonly User _userContext;

        public UserRL(User _userContext)
        {
            this._userContext = _userContext;
        }
       /* public User Authenticate(string email, string password)
        {
            try
            {
                var user = _userContext.User.FirstOrDefault(x => x.Email == email && x.Password == password);
                //return null if user is not found 
                if (user == null)
                    return null;
                //if user found 



                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
    }
}
