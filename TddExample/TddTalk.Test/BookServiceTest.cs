using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExample.Services.Interfaces;
using TddExample.Services.Model;
using TddExample.Services.Services;
using TddTalk.DataLayer.Interfaces;
using TddTalk.DataLayer.Model;

namespace TddTalk.Test
{
    [TestClass]
    public class BookServiceTest
    {
        private BookService _bookService;
        private Mock<IBookRepository> _bookRepository;
        [TestInitialize] public void SetUp() 
        {
            _bookRepository = new Mock<IBookRepository>();
            _bookService = new BookService(_bookRepository.Object);
        }
        [TestMethod]
        public void ShouldReturnAListOfBooks()
        {
            var authorId = 2;
            var books = new List<Book>()
            {
                new Book
                { 
                    Id = 5,
                    Title="Growing Object-Oriented Software Guided by Tests",
                    AuthorId=2,
                    ISBN="9780321503626",
                    CreationDate=new DateTime(2009,01,01),
                    Author = new Author
                    {
                        Id=2,
                        FirstName="Nat",
                        LastName="Price"
                    }
                }
            };
            _bookRepository.Setup(b => b.GetByAuthorId(authorId)).Returns(books);

            var mockBooks = new List<BookSearchDto>()
            {
                new BookSearchDto
                    {
                    Id = 5,
                    Title="Growing Object-Oriented Software Guided by Tests",
                    AuthorId=2,
                    ISBN="9780321503626",
                    CreationDate=new DateTime(2009,01,01),
                }
            };

            var result = _bookService.GetByAuthorId(authorId);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<BookSearchDto>));
        }

        [TestMethod]
        public void ShouldGetTheListWithBooksForAuthorId2()
        {
            var authorId = 2;
            var books = new List<Book>()
            {
                new Book
                {
                    Id = 5,
                    Title="Growing Object-Oriented Software Guided by Tests",
                    AuthorId=2,
                    ISBN="9780321503626",
                    CreationDate=new DateTime(2009,01,01),
                    Author = new Author
                    {
                        Id=2,
                        FirstName="Nat",
                        LastName="Price"
                    }
                }
            };
            _bookRepository.Setup(b => b.GetByAuthorId(authorId)).Returns(books);

            var mockBooks = new List<BookSearchDto>()
            {
                new BookSearchDto
                    {
                    Id = 5,
                    Title="Growing Object-Oriented Software Guided by Tests",
                    AuthorId=2,
                    ISBN="9780321503626",
                    CreationDate=new DateTime(2009,01,01),
                }
            };

            var result = _bookService.GetByAuthorId(authorId);

            Assert.IsNotNull(result);
            Assert.AreEqual(mockBooks.FirstOrDefault().ISBN, result.FirstOrDefault().ISBN);
            Assert.AreEqual(mockBooks.FirstOrDefault().Id, result.FirstOrDefault().Id);
            Assert.AreEqual(mockBooks.FirstOrDefault().Title, result.FirstOrDefault().Title);

        }
    }
}
