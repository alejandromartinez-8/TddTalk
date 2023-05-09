using Moq;
using TddExample.Controllers;
using TddExample.Services.Interfaces;
using TddExample.Services.Model;

namespace TddTalk.Test
{
    [TestClass]
    public class BookControllerTest
    {
        private BookController? _bookController;
        private Mock<IBookService>? _bookService;

        [TestInitialize]
        public void Setup()
        {
            _bookService = new Mock<IBookService>();
            _bookController = new BookController(_bookService.Object);
        }

        [TestMethod]
        public void GetByAuthorIdShouldReturnAListOfBooks()
        {
            var authorId = 1;
            var book = new BookSearchDto
            {
                AuthorId = authorId,
                Id = 1,
                Title = "Test Book",
                ISBN= "1",
                CreationDate = DateTime.Now,
            };

            var mockBooks = new List<BookSearchDto>() { book };

            _bookService?.Setup(s => s.GetByAuthorIdAsync(authorId)).ReturnsAsync(mockBooks);

            var books = _bookController.GetByAuthorId(authorId);

            Assert.IsNotNull(books);
            Assert.AreEqual(books.Result, mockBooks);
        }

        [TestMethod]
        public void GetByAuthorIdShouldThrowExceptionIfAuthorDoesNotExists()
        {
            var authorId = 1;
            var exception = new Exception("Author does not exist");
            _bookService?.Setup(s => s.GetByAuthorIdAsync(authorId)).Throws(exception);

            var result = _bookController.GetByAuthorId(authorId);

            Assert.AreEqual(result.Exception.InnerException, exception);
        }

        [TestMethod]
        public void GetByAuthorIdShouldReturnAEmptyListIfAuthorDoesNotHaveAnyBook()
        {
            var authorId = 1;
            var mockBooks = new List<BookSearchDto>();

            _bookService?.Setup(s => s.GetByAuthorIdAsync(authorId)).ReturnsAsync(mockBooks);

            var books = _bookController.GetByAuthorId(authorId);

            Assert.IsNotNull(books);
            Assert.AreEqual(books.Result.Count, 0);
        }

    }
}