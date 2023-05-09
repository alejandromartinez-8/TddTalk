using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExample.Services.Model;

namespace TddExample.Services.Interfaces
{
    public interface IBookService
    {
        List<BookSearchDto> GetByAuthorId(int authorId);
    }
}
