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
        private int _authorId = 2;
        private List<Book> _books;
        private List<BookSearchDto> _mockBooks;
        private Mock<IBookRepository> _bookRepository;
        private BookService _bookService;

        [TestInitialize] 
        public void SetUp() 
        {
            _bookRepository = new Mock<IBookRepository>();
            _bookService = new BookService(_bookRepository.Object);
            _books = new List<Book>()
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
            _mockBooks = new List<BookSearchDto>()
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
        }
        [TestMethod]
        public void Should_GetAListOfBooks_When_AuthorExists()
        {
            
            _bookRepository.Setup(b => b.GetByAuthorId(_authorId)).Returns(_books);

            var result = _bookService.GetByAuthorId(_authorId);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<BookSearchDto>));
        }

        [TestMethod]
        public void Should_GetTheListWithBooks_When_AuthorIdIsEqualTo2()
        {
            _bookRepository.Setup(b => b.GetByAuthorId(_authorId)).Returns(_books);

            var result = _bookService.GetByAuthorId(_authorId);

            Assert.IsNotNull(result);
            Assert.AreEqual(_mockBooks.FirstOrDefault().ISBN, result.FirstOrDefault().ISBN);
            Assert.AreEqual(_mockBooks.FirstOrDefault().Id, result.FirstOrDefault().Id);
            Assert.AreEqual(_mockBooks.FirstOrDefault().Title, result.FirstOrDefault().Title);

        }
    }
}
