using Xunit;
using dopustim.Data;
using dopustim.Models;
using dopustim.Patterns;
using Microsoft.EntityFrameworkCore;

public class EditBookCommandTests
{
    [Fact]
    public void Execute_EditsBookInDatabase()
    {
        var options = new DbContextOptionsBuilder<LibraryContext>()
            .UseInMemoryDatabase(databaseName: "TestDb_Edit")
            .Options;

        using var db = new LibraryContext(options);
        var book = new Book { Title = "Старое название", Author = "Автор", UserId = 1 };
        db.Books.Add(book);
        db.SaveChanges();

        // Меняем название книги
        book.Title = "Новое название";
        var command = new EditBookCommand(book);
        command.Execute(db);

        Assert.Equal("Новое название", db.Books.First().Title);
    }
}
