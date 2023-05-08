using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TddTalk.DataLayer.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Editorial { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string Icbn { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
