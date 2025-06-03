using Xunit;
using dopustim.Data;
using dopustim.Models;
using dopustim.Patterns;
using Microsoft.EntityFrameworkCore;

public class AddBookCommandTests
{
    [Fact]
    public void Execute_AddsBookToDatabase()
    {
        // Arrange: создаём in-memory базу
        var options = new DbContextOptionsBuilder<LibraryContext>()
            .UseInMemoryDatabase(databaseName: "TestDb_Add")
            .Options;

        using var db = new LibraryContext(options);
        var book = new Book { Title = "Тестовая книга", Author = "Автор", UserId = 1 };
        var command = new AddBookCommand(book);

        // Act
        command.Execute(db);

        // Assert
        Assert.Single(db.Books);
        Assert.Equal("Тестовая книга", db.Books.First().Title);
    }
}
