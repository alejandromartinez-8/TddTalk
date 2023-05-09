using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddTalk.DataLayer.Model;

namespace TddTalk.DataLayer.Context
{
    public class BookContext
    {
        private readonly string _filePath;
        public BookContext(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<Book> Books
        {
            get { return ReadDataFromFile<Book>(_filePath + "..\\..\\..\\..\\TddTalk.DataLayer\\books.json"); }
            set { WriteDataToFile<Book>(_filePath + "..\\..\\..\\..\\TddTalk.DataLayer\\books.json", value); }
        }

        private IEnumerable<T> ReadDataFromFile<T>(string filePath)
        {
            // Leer los datos desde el archivo y deserializarlos en una lista de objetos del tipo T
            string jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonData);
        }

        private void WriteDataToFile<T>(string filePath, IEnumerable<T> data)
        {
            // Serializar los datos en formato JSON y escribirlos en el archivo
            string jsonData = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
