using dopustim.Data;

namespace dopustim.Patterns
{
    public interface IBookCommand
    {
        void Execute(LibraryContext db);
    }
}

