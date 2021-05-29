using Common_Layer.Models;
using CommonLayer.Models;
using MongoDB.Driver;
using RepositoryLayer.DatabaseSetting;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class WishlistRL : IWishlistRL
    {
        private readonly IMongoCollection<User> _users;
        private readonly IMongoCollection<WishList> _wishList;
        private readonly IMongoCollection<Cart> _cart;
        public WishlistRL(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
            _wishList = database.GetCollection<WishList>(settings.WishListCollectionName);
            _cart = database.GetCollection<Cart>(settings.CartCollectionName);
        }
        public List<WishList> GetWishList(string id) =>
                this._wishList.Find<WishList>(list => list.UserId == id).ToList();
    }
}
