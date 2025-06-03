using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dopustim.Data;
using dopustim.Models;
using System.Linq;
using System.Threading.Tasks;
using dopustim.Patterns;

namespace dopustim.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _db;

        public BooksController(LibraryContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks(int userId)
        {
            var books = await _db.Books.Where(b => b.UserId == userId).ToListAsync();
            return Ok(books);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            var command = new AddBookCommand(book);
            command.Execute(_db);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var command = new DeleteBookCommand(id);
            command.Execute(_db);
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Book updated)
        {
            updated.Id = id; 
            var command = new EditBookCommand(updated);
            command.Execute(_db);
            return Ok(updated);
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchBooks(int userId, string query)
        {
            var books = await _db.Books
                .Where(b => b.UserId == userId &&
                           (b.Title.Contains(query) || b.Author.Contains(query)))
                .ToListAsync();

            return Ok(books);
        }
    }
}
