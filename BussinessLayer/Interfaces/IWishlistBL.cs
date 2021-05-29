using Common_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    public interface IWishlistBL
    {
        public List<WishList> GetWishList(string id);
    }
}
