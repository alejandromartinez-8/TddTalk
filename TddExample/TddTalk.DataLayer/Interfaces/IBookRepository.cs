using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddTalk.DataLayer.Model;

namespace TddTalk.DataLayer.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book>GetByAuthorId(int authorId);
    }
}
