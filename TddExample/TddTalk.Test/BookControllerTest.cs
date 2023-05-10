using System;
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

        [TestInitialize] public void SetUp() 
        {

        }

        [TestMethod]
        public void Should_GetAListOfBooks_When_AnAuthorHasBooks()
        {

        }

        [TestMethod]
        public void Should_GetAnEmptyList_When_AuthorDoesNotExist()
        {

        }

        [TestMethod]
        public void Should_GetAnEmptyList_When_AuthorDoesNotHaveAnyBook()
        {

        }
    }
}
