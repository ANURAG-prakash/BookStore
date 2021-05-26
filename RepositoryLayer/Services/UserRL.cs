using CommonLayer.Models;
using MongoDB.Driver;
using RepositoryLayer.DatabaseSetting;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
   public  class UserRL : IUserRL

    {
        private readonly IMongoCollection<User> _users;

        public UserRL(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public User Authenticate(string Email, string Password)
        {
            try
            {
                var user = this._users.Find<User>(User => User.Email == Email && User.Password == Password);
                //return null if user is not found 
                if (user == null)
                    return null;
                //if user found 



                return (User)user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
