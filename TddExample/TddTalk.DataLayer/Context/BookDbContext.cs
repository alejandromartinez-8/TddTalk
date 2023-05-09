using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddTalk.DataLayer.Model;

namespace TddTalk.DataLayer.Context
{
    public class BookDbContext : IDisposable
    {
        private readonly BookContext _bookContext;

        public BookDbContext(string filePath)
        {
            _bookContext = new BookContext(filePath);
        }

        public IEnumerable<Book> Books => _bookContext.Books;

        public void SaveChanges() { }
        public void Dispose() { }
    }
}
