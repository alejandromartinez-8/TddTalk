using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExample.Services.Services;
using TddTalk.DataLayer.Interfaces;
using TddTalk.DataLayer.Model;
using TddTalk.DataLayer.Repository;

namespace TddTalk.Test
{
    [TestClass]
    public class BookServiceTest
    {
        private BookRepository _bookRepository;
        private BookService _bookService;
        [TestInitialize]
        public void Setup()
        {
            _bookRepository = new BookRepository("");
            _bookService = new BookService(_bookRepository);
        }

        [TestMethod]
        public void ShouldReturnAnIEnumerableOfBooks()
        {
            var books = _bookService.GetByAuthorId(1);

            Assert.IsNotNull(books);
            Assert.IsInstanceOfType(books, typeof(IEnumerable<Book>));
        }

        [TestMethod]
        public void ShouldGetTheListWithBooksForAuthorId2()
        {
            var bookList = new List<Book>()
            {
                new Book
                    {
                    Id = 5,
                    Title="Growing Object-Oriented Software Guided by Tests",
                    AuthorId=2,
                    ISBN="9780321503626",
                    CreationDate=new DateTime(2009,01,01),
                    Author= new Author{
                        Id=2,
                        FirstName="Nat",
                        LastName="Price"
                        }
                    },
                new Book{
                    Id=6,
                    Title="Java To Kotlin",
                    AuthorId=2,
                    ISBN="9781492082279",
                    CreationDate= new DateTime(2021,01,01),
                    Author = new Author{
                        Id=2,
                        FirstName="Nat",
                        LastName="Price"
                    }
                }
            };
            var books = _bookService.GetByAuthorId(2);

            Assert.IsNotNull(books);
            Assert.AreEqual(bookList.FirstOrDefault().ISBN, books.ToList().FirstOrDefault().ISBN);
            Assert.AreEqual(bookList.FirstOrDefault().Id, books.ToList().FirstOrDefault().Id);
            Assert.AreEqual(bookList.FirstOrDefault().Title, books.ToList().FirstOrDefault().Title);
            Assert.AreEqual(bookList.ElementAt(1).ISBN, books.ToList().ElementAt(1).ISBN);
            Assert.AreEqual(bookList.ElementAt(1).Id, books.ToList().ElementAt(1).Id);
            Assert.AreEqual(bookList.ElementAt(1).Title, books.ToList().ElementAt(1).Title);
        }
    }
}
