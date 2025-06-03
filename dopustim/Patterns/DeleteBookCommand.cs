using dopustim.Data;

namespace dopustim.Patterns
{
    public class DeleteBookCommand : IBookCommand
    {
        private readonly int _bookId;
        public DeleteBookCommand(int bookId) => _bookId = bookId;

        public void Execute(LibraryContext db)
        {
            var book = db.Books.Find(_bookId);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }
    }
}
