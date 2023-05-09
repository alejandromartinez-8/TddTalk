using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddTalk.DataLayer.Context;
using TddTalk.DataLayer.Interfaces;
using TddTalk.DataLayer.Model;

namespace TddTalk.DataLayer.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _context;
        public BookRepository(string filePath)
        {
            _context = new BookDbContext(filePath);
        }

        public IEnumerable<Book> GetByAuthorId(int authorId)
        {
            return _context.Books.Where(b => b.AuthorId== authorId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
