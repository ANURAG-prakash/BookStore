using BussinessLayer.Interfaces;
using Common_Layer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class WishlistBL : IWishlistBL
    {

        private readonly IWishlistRL wishListRL;
        public WishlistBL(IWishlistRL wishListRL)
        {
            this.wishListRL = wishListRL;
        }
        public List<WishList> GetWishList(string id)
        {
            try
            {
                return wishListRL.GetWishList(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public dynamic GetWishListBooks(string userId)
        {

            try
            {
                return wishListRL.GetWishList(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(string bookid, string userId)
        {
            try
            {
                this.wishListRL.Remove(bookid , userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
