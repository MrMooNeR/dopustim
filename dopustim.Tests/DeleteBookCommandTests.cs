using Xunit;
using dopustim.Data;
using dopustim.Models;
using dopustim.Patterns;
using Microsoft.EntityFrameworkCore;

public class DeleteBookCommandTests
{
    [Fact]
    public void Execute_DeletesBookFromDatabase()
    {
        var options = new DbContextOptionsBuilder<LibraryContext>()
            .UseInMemoryDatabase(databaseName: "TestDb_Delete")
            .Options;

        using var db = new LibraryContext(options);
        var book = new Book { Title = "Удалить", Author = "Автор", UserId = 1 };
        db.Books.Add(book);
        db.SaveChanges();

        var command = new DeleteBookCommand(book.Id);
        command.Execute(db);

        Assert.Empty(db.Books);
    }
}
