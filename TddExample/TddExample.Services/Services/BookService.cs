using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExample.Services.Interfaces;
using TddTalk.DataLayer.Interfaces;
using TddTalk.DataLayer.Model;

namespace TddExample.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetByAuthorId(int authorId)
        {
            return _bookRepository.GetByAuthorId(authorId);
        }
    }
}
