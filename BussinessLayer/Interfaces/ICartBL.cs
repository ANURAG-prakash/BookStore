﻿// <auto-generated />
using Common_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    public interface ICartBL 
    {

        public Orders Create(Orders order);
        public List<Cart> GetCart(string id);

        public void Remove(string bookid, string userId);
    }
}
