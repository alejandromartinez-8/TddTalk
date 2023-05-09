﻿using Microsoft.AspNetCore.Http;
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
        public async Task<List<BookSearchDto>> GetByAuthorId(int authorId)
        {
            try
            {
                return await _bookService.GetByAuthorIdAsync(authorId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
