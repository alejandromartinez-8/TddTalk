﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExample.Controllers;
using TddExample.Services.Interfaces;
using TddExample.Services.Services;
using TddTalk.DataLayer.Repository;

namespace TddTalk.Test
{
    [TestClass]
    public class BookControllerTest
    {
        private BookController _bookController;
        [TestInitialize] public void SetUp() 
        {
            var bookRepository = new BookRepository("");
            var bookService = new BookService(bookRepository);
            _bookController = new BookController(bookService);
        }

        [TestMethod]
        public void Should_GetAListOfBooks_When_AnAuthorHasBooks()
        {
            var books = _bookController.GetByAuthorId(1);

            Assert.IsNotNull(books);
            Assert.AreEqual(1,books.FirstOrDefault().AuthorId);
        }

        [TestMethod]
        public void Should_GetAnEmptyList_When_AuthorDoesNotExist()
        {
            var books = _bookController.GetByAuthorId(4);

            Assert.IsNotNull(books);
            Assert.AreEqual(0, books.Count());

        }

        [TestMethod]
        public void Should_GetAnEmptyList_When_AuthorDoesNotHaveAnyBook()
        {
            var books = _bookController.GetByAuthorId(3);

            Assert.IsNotNull(books);
            Assert.AreEqual(0, books.Count());
        }
    }
}