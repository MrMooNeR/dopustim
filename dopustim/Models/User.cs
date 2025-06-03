using System.Collections.Generic;

namespace dopustim.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public List<Book> Books { get; set; } = new();
    }
}
