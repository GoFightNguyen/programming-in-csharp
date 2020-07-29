using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace _4._35_SqlCommand_Parameterized
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public async Task InsertRowWithParameterizedQuery()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("Insert into people([FirstName], [LastName]) VALUES(@firstName, @lastName)", connection);
                await connection.OpenAsync();

                command.Parameters.AddWithValue("@firstName", "john");
                command.Parameters.AddWithValue("@lastName", "doe");

                int numberOfInsertedRows = await command.ExecuteNonQueryAsync();
            }
        }
    }
}
