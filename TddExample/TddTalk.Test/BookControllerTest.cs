using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExample.Controllers;
using TddExample.Services.Interfaces;
using TddExample.Services.Services;

namespace TddTalk.Test
{
    [TestClass]
    public class BookControllerTest
    {
        private BookController _bookController;
        [TestInitialize] public void SetUp() 
        {
            
        }

        [TestMethod]
        public void ShouldReturnListWithBooksRelatedToSpecifiedAuthor()
        {
            var books = _booksController.GetByAuthorId(1);

            Assert.IsNotNull(books);
            Assert.AreEqual(1,books.FirstOrDefault().AuthorId);
        }

        [TestMethod]
        public void ShouldThrowAnExceptionIfTheAuthorDoesNotExist()
        {
            var books = _booksController.GetByAuthorId(3);

            
        }

        [TestMethod]
        public void ShouldReturnAnEmptyListIfTheAuthorDoesNotHaveAnyBook()
        {
            var books = _booksController.GetByAuthorId(3);

            Assert.IsNotNull(books);
            Assert.AreEqual(0, books.Count());
        }
    }
}
