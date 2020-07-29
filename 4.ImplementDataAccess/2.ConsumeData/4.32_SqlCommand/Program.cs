using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace _4._32_SqlCommand
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public async Task SelectDataFromTable()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("select * from people", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while(await reader.ReadAsync())
                {
                    string format = "Person ({0}) is named {1} {2}";
                    if(reader["middlename"] == null)
                        Console.WriteLine(format, reader["firstname"], reader["lastname"]);
                    else
                        Console.WriteLine(format, reader["firstname"], reader["lastname"]);
                }

                reader.Close();
            }
        }
    }
}
