using Microsoft.Data.Sqlite;
using System.Reflection;

namespace Cracker
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var asmMain = Assembly.LoadFrom("ZackDictCore.dll");
            Thread thread = new Thread(() => {
                MessageBox.Show("Wait");
                try
                {
                    var form = Application.OpenForms[0];
                    var fieldSqliteConnection = form.GetType().GetMembers(BindingFlags.Public | BindingFlags.NonPublic |
                                            BindingFlags.Instance | BindingFlags.Static |
                                            BindingFlags.DeclaredOnly)
                                            .Where(e => e.MemberType == MemberTypes.Field)
                         .Select(e => (FieldInfo)e).Where(e => e.FieldType.Name.Contains("SqliteConnection"))
                                            .FirstOrDefault();
                    var sqliteConnection = (SqliteConnection)fieldSqliteConnection.GetValue(form);
                    sqliteConnection.Open();
                    /*
                    SqliteConnection destConnection = new SqliteConnection("Data Source=decrypted.db");
                    destConnection.Open();
                    sqliteConnection.BackupDatabase(destConnection);
                    destConnection.Close();*/
                    /*
                    using var cmd = sqliteConnection.CreateCommand();
                    cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table'";
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string tableName = reader.GetString(0);
                        MessageBox.Show(tableName);
                    }*/
                    /*
                    using var cmd = sqliteConnection.CreateCommand();
                    cmd.CommandText = "PRAGMA table_info(Words)";
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string fieldName = reader.GetString(reader.GetOrdinal("name"));
                        string type = reader.GetString(reader.GetOrdinal("type"));
                        MessageBox.Show(fieldName+","+type);
                    }*/
                    using var cmd = sqliteConnection.CreateCommand();
                    cmd.CommandText = "select word, chinese from Words limit 2";
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string word = reader.GetString(0);
                        string chinese = reader.GetString(1);
                        MessageBox.Show(word + "," + chinese);
                        return;
                    }
                    MessageBox.Show("Done");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
            thread.Start();
            asmMain.EntryPoint.Invoke(null, new object[0]);
        }
    }
}