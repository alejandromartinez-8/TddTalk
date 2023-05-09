using TddTalk.DataLayer.Context;
using TddTalk.DataLayer.Model;
using TddTalk.DataLayer.Repository;

namespace TddTalk.Test
{
    [TestClass]
    public class BookRepositoryTest
    {
        private BookRepository _bookRepository;
        [TestInitialize]
        public void Setup()
        {
            var filePath = "";
            _bookRepository = new BookRepository(filePath);
        }

        [TestMethod]
        public void BooksShouldHaveTitleISBNCreationDateAuthorIdAndId()
        {
            var books = _bookRepository.GetByAuthorId(1);

            Assert.IsNotNull(books);
            Assert.IsNotNull(books.FirstOrDefault().Id);
            Assert.IsNotNull(books.FirstOrDefault().Title);
            Assert.IsNotNull(books.FirstOrDefault().ISBN);
            Assert.IsNotNull(books.FirstOrDefault().CreationDate);
            Assert.IsNotNull(books.FirstOrDefault().AuthorId);
        }
        [TestMethod]
        public void AuthorShouldHaveFirstNameLastNameAndId()
        {
            
            var books = _bookRepository.GetByAuthorId(1);

            Assert.IsNotNull(books);
            Assert.IsNotNull(books.FirstOrDefault().Author.Id);
            Assert.IsNotNull(books.FirstOrDefault().Author.FirstName);
            Assert.IsNotNull(books.FirstOrDefault().Author.LastName);
        }
        [TestMethod]
        public void ShouldGetAListOfBooksWithSomeElements()
        {
            var books = _bookRepository.GetByAuthorId(1);

            Assert.IsNotNull(books);
            Assert.AreNotSame(0, books.Count());
        }
    }
}