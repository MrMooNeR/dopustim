using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryClient
{
    public partial class BooksForm : Form
    {
        private readonly string _token;
        private readonly int _userId;
        public BooksForm(string token, int userId)
        {
            InitializeComponent();
            _token = token;
            _userId = userId;
        }

        private void BooksForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private async void LoadBooks()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7174/"); // твой адрес!
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await client.GetAsync($"api/Books?userId={_userId}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var books = JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                dataGridViewBooks.DataSource = null;
                dataGridViewBooks.DataSource = books;
            }
        }

        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            var editForm = new BookEditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                var book = new Book
                {
                    Title = editForm.BookTitle,
                    Author = editForm.BookAuthor,
                    UserId = _userId
                };

                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7174/");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

                var json = JsonSerializer.Serialize(book);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("api/Books", content);
                if (response.IsSuccessStatusCode)
                    LoadBooks();
                else
                    MessageBox.Show("Ошибка при добавлении книги!");
            }
        }

        private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow == null)
                return;

            var book = dataGridViewBooks.CurrentRow.DataBoundItem as Book;
            if (book == null) return;

            var result = MessageBox.Show($"Удалить книгу \"{book.Title}\"?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7174/");
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

            var response = await client.DeleteAsync($"api/Books/{book.Id}");
            if (response.IsSuccessStatusCode)
                LoadBooks();
            else
                MessageBox.Show("Ошибка при удалении книги!");
        }

        private async void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow == null)
                return;

            var book = dataGridViewBooks.CurrentRow.DataBoundItem as Book;
            if (book == null) return;

            var editForm = new BookEditForm(book.Title, book.Author);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                book.Title = editForm.BookTitle;
                book.Author = editForm.BookAuthor;

                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7174/");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

                var json = JsonSerializer.Serialize(book);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"api/Books/{book.Id}", content);
                if (response.IsSuccessStatusCode)
                    LoadBooks();
                else
                    MessageBox.Show("Ошибка при изменении книги!");
            }
        }

        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            string query = textBoxSearch.Text.Trim();

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7174/");
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

            // Используем эндпоинт поиска на сервере!
            var response = await client.GetAsync($"api/Books/search?userId={_userId}&query={query}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var books = JsonSerializer.Deserialize<List<Book>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                dataGridViewBooks.DataSource = null;
                dataGridViewBooks.DataSource = books;
            }
        }

    }
}
