using dopustim.Models;
using dopustim.Data;

namespace dopustim.Patterns
{
    public class EditBookCommand : IBookCommand
    {
        private readonly Book _updatedBook;
        public EditBookCommand(Book updatedBook) => _updatedBook = updatedBook;

        public void Execute(LibraryContext db)
        {
            var book = db.Books.Find(_updatedBook.Id);
            if (book != null)
            {
                book.Title = _updatedBook.Title;
                book.Author = _updatedBook.Author;
                db.SaveChanges();
            }
        }
    }
}
