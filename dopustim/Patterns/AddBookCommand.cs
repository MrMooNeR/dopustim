using dopustim.Data;
using dopustim.Models;

namespace dopustim.Patterns
{
    public class AddBookCommand : IBookCommand
    {
        private readonly Book _book;
        public AddBookCommand(Book book) => _book = book;

        public void Execute(LibraryContext db)
        {
            db.Books.Add(_book);
            db.SaveChanges();
        }
    }

}
