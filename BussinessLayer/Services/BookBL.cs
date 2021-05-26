﻿using BussinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class BookBL : IBookBL
    {

        readonly IBookRL bookRL;
        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }

        public Book Create(Book book)
        {
            return this.bookRL.Create(book);
        }

        public List<Book> Get()
        {
            return this.bookRL.Get();
        }

        public Book Get(string id)
        {
            return this.bookRL.Get(id);
        }

        public void Remove(Book bookIn)
        {
             this.bookRL.Remove(bookIn);
        }

        public void Remove(string id)
        {
            this.bookRL.Remove(id);
        }

        public void Update(string id, Book bookIn)
        {
            this.bookRL.Update(id ,bookIn);
        }
    }
}
