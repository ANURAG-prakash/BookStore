// <auto-generated />
using System;
using System.Collections.Generic;
using System.Text;
using Common_Layer.Models;


namespace RepositoryLayer.Interfaces
{
    public interface ICartRL
    {
        public Orders Create(Orders order);
        public dynamic GetCart(string id);
        public void Remove(string bookid, string userId);

    }
}
