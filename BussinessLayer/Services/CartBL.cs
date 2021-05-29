﻿// <auto-generated />
using BussinessLayer.Interfaces;
using Common_Layer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class CartBL : ICartBL
    {
        readonly ICartRL cartRL;

        public CartBL(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }
        public Orders Create(Orders order)
        {
            return this.cartRL.Create(order);
        }

        public List<Cart> GetCart(string id)
        {
            try
            {
                return this.cartRL.GetCart(id);
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
                this.cartRL.Remove(bookid, userId);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}