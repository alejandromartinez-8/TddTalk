using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExample.Services.Interfaces;
using TddExample.Services.Model;
using TddTalk.DataLayer.Interfaces;

namespace TddExample.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<BookSearchDto> GetByAuthorId(int authorId)
        {
            var books = _bookRepository.GetByAuthorId(authorId);
            return books.Select(b => new BookSearchDto
            {
                Id = b.Id,
                ISBN = b.ISBN,
                Title = b.Title,
                AuthorId = b.AuthorId,
                CreationDate = b.CreationDate,
            }).ToList();
        }
    }
}
