using Moq;
using TddExample.Services.Model;

namespace TddTalk.Test
{
    [TestClass]
    public class BookControllerTest
    {
        private BookController? _bookController;
        private Mock<IBookService>? _bookService;
        private int _authorId = 1;
        private List<BookSearchDto> _mockBooks= new List<BookSearchDto>();

        [TestInitialize]
        public void Setup()
        {
            _bookService = new Mock<IBookService>();
            _bookController = new BookController(_bookService.Object);
        }

        [TestMethod]
        public void Should_GetAListOfBooks_When_AnAuthorHasBooks()
        {
            var book = new BookSearchDto
            {
                AuthorId = _authorId,
                Id = 1,
                Title = "Test Book",
                ISBN= "1",
                CreationDate = DateTime.Now,
            };

            _mockBooks = new List<BookSearchDto>() { book };

            _bookService?.Setup(s => s.GetByAuthorId(_authorId)).Returns(_mockBooks);

            var books = _bookController.GetByAuthorId(_authorId);

            Assert.IsNotNull(books);
            Assert.AreEqual(_mockBooks, books);
        }

        [TestMethod]
        public void Should_GetAnEmptyList_When_AuthorDoesNotExist()
        {
            _authorId = 4;

            _bookService?.Setup(s => s.GetByAuthorId(_authorId)).Returns(_mockBooks);

            var result = _bookController.GetByAuthorId(_authorId);

            Assert.AreEqual(_mockBooks, result);
        }

        [TestMethod]
        public void Should_GetAnEmptyList_When_AuthorDoesNotHaveAnyBook()
        {
            _authorId = 3;

            _bookService?.Setup(s => s.GetByAuthorId(_authorId)).Returns(_mockBooks);

            var books = _bookController.GetByAuthorId(_authorId);

            Assert.IsNotNull(books);
            Assert.AreEqual(0, books.Count);
        }

    }
}