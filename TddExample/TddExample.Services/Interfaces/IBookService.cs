using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddTalk.DataLayer.Model;

namespace TddExample.Services.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetByAuthorId(int authorId);
    }
}
