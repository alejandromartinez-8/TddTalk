using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TddExample.Services.Interfaces;
using TddExample.Services.Model;

namespace TddExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public List<BookSearchDto> GetByAuthorId(int authorId)
        {
            return _bookService.GetByAuthorId(authorId).ToList();
        }
    }
}
