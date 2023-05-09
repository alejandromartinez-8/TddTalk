﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TddExample.Services.Interfaces;

namespace TddExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public List<BookSearchDto> GetByAuthorId(int authorId)
        {

        }
    }
}
