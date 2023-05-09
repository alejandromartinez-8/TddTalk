using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExample.Services.Model;
using TddTalk.DataLayer.Model;

namespace TddExample.Services.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookSearchDto> GetByAuthorId(int authorId);
    }
}
