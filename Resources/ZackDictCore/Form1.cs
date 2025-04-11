using Microsoft.Data.Sqlite;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ZackDictCore
{
    public partial class Form1 : Form
    {
        private SqliteConnection _connection;
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += Form1_FormClosed;    
        }

        private void Form1_FormClosed(object? sender, FormClosedEventArgs e)
        {
            _connection?.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var connectionString = new SqliteConnectionStringBuilder()
            {
                DataSource = "dict.db",
                Mode = SqliteOpenMode.ReadWrite,
                Password = "ab%A1l010o1"
            }.ToString();
            _connection = new SqliteConnection(connectionString);
            _connection.Open();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using var cmd = _connection.CreateCommand();
            cmd.CommandText = $"select Chinese from Words where Word=@Word";
            cmd.Parameters.AddWithValue("@Word", txtWord.Text);
            var chinese = (string?)cmd.ExecuteScalar();
            if (chinese != null)
            {
                txtResult.Text = chinese;
            }
            else
            {
                txtResult.Text="Word not found";
            }

        }
    }
}
