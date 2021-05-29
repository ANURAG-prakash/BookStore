using Common_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IWishlistRL
    {
        public List<WishList> GetWishList(string id);
    }
}
