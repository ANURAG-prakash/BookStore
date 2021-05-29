﻿// <auto-generated />
using BussinessLayer.Interfaces;
using Common_Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStoreApi.Controllers
{
   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CartController : Controller
    {
        private readonly IBookBL _bookBL;
        private readonly ICartBL _cartBL;
        public CartController(IBookBL _bookBL, ICartBL _cartBL)
        {
            this._bookBL = _bookBL;
            this._cartBL = _cartBL;
        }


        private List<string> GetTokenType()
        {
            string id = User.FindFirst("Id").Value;
            string type = User.FindFirst("ServiceType").Value;
            List<string> x = new List<string>();
            x.Add(id);
            x.Add(type);
            return x;
        }

        [HttpGet]
        public ActionResult GetCartBook()
        {

            if (GetTokenType()[1] != "User")
            {

                return this.BadRequest(new { success = false, message = "Only Users Allowed" });
            }

            var book = _cartBL.GetCart(GetTokenType()[0]);
            return this.Ok(new { success = true, book });
        }

        [HttpPut("/Order/{bookId}/{quantity}")]
        public IActionResult OrderBook(string bookId,  int quantity)
        {
            if (GetTokenType()[1] != "User")
            {
                return this.BadRequest(new { success = false, message = "Only Users Allowed" });
            }

            var cartBook = _cartBL.GetCart(GetTokenType()[0]);
            var book = _bookBL.Get(bookId);

            if (cartBook == null)
            {
                return this.BadRequest(new { success = false, message = "Book is not in Cart" });
            }

            book.AvailableBooks = book.AvailableBooks - quantity;

            if (book.AvailableBooks >= 0)
            {
                _bookBL.Update(bookId, book);
                _cartBL.Remove(bookId, GetTokenType()[0]);
                Orders order = new Orders() { BookName = book.BookName, Price = book.Price};
                _cartBL.Create(order);
                return this.Ok(new { success = true, message = "Book Ordered" });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Book Order Failed due to Availablity" });
            }
        }
    }

}

