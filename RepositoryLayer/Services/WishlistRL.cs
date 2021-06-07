using Common_Layer.Models;
using CommonLayer.Models;
using MongoDB.Driver;
using RepositoryLayer.DatabaseSetting;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RepositoryLayer.Services
{
    public class WishlistRL : IWishlistRL
    {
        private readonly IMongoCollection<User> _users;
        private readonly IMongoCollection<WishList> _wishList;
        private readonly IMongoCollection<Cart> _cart;
        private readonly IMongoCollection<Book> _book;
        public WishlistRL(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
            _wishList = database.GetCollection<WishList>(settings.WishListCollectionName);
            _cart = database.GetCollection<Cart>(settings.CartCollectionName);
            _book = database.GetCollection<Book>(settings.BooksCollectionName);
        }
        public List<WishList> GetWishList(string id) =>
                this._wishList.Find<WishList>(list => list.UserId == id).ToList();

        public void Remove(string id, string userId) =>
           this._wishList.DeleteOne(book => book.BookId == id && book.UserId == userId);

        public dynamic GetWishlistBooks(string userId)
        {
            try
            {
                var data = from c in _wishList.AsQueryable()
                           join b in _book.AsQueryable()
                           on c.BookId equals b.Id into result
                           where c.UserId == userId
                           select new
                           {
                               BookName = result.First().BookName,
                               Price = result.First().Price,
                               Author = result.First().Authors,
                               BookId = c.BookId,
                               CartId = c.Id,
                               Email = c.Email
                           };

               
                return data.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
