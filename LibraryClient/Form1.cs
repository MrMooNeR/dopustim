using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace LibraryClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            var login = textBoxLogin.Text.Trim();
            var password = textBoxPassword.Text;

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7174/");

            var data = new { username = login, password = password };
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("api/Auth/login", content);
                if (response.IsSuccessStatusCode)
                {
                    var respJson = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(respJson);
                    string token = doc.RootElement.GetProperty("token").GetString();

                    int userId = doc.RootElement.TryGetProperty("userId", out var idProp) ? idProp.GetInt32() : 0;

                    var booksForm = new BooksForm(token, userId);
                    booksForm.Show();
                    this.Hide();

                    MessageBox.Show("Успешный вход! Токен получен.");
                }
                else
                {
                    labelError.Text = "Ошибка входа!";
                }
            }
            catch (Exception ex)
            {
                labelError.Text = $"Ошибка: {ex.Message}";
            }
        }
    }
}
