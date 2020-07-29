using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace _4._34_SqlCommand_ExecuteNonQuery
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public async Task UpdateRows()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("Update people set FirstName='John'", connection);
                await connection.OpenAsync();
                var numberOfUpdatedRows = await command.ExecuteNonQueryAsync();
                Console.WriteLine(numberOfUpdatedRows);
            }
        }
    }
}
