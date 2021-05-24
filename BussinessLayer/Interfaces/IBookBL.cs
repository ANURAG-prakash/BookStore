using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    public interface IBookBL
    {
        public List<Book> Get();
        public Book Get(string id);
        public Book Create(Book book);
        public void Update(string id, Book bookIn);
        public void Remove(Book bookIn);
        public void Remove(string id);
    }
}
