using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3 {
    public class Book: Item {
        public int PageCount { get; set; }
        public IList<Author> Authors;
        public Book(string title,
                    int id,
                    string publisher,
                    DateTime dateOfIssue,
                    int pageCount,
                    IList<Author> authors) : base(title, id, publisher, dateOfIssue) {
            PageCount = pageCount;
            Authors = authors;
        }
        public override string ToString() {
            string auth = $"{base.ToString().TrimEnd('\n')}, Page Count: {PageCount}\nAuthors:\n";
            foreach (Author author in Authors) {
                auth += author.ToString();
            }
            return auth;
        }
        public override string GenerateBarCode() {
            return "1234book";
        }
        public void AddAuthor(Author author) {
            Authors.Add(author);
        }
    }
}
