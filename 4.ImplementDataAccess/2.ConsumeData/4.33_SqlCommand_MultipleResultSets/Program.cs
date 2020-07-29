using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace _4._33_SqlCommand_MultipleResultSets
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public async Task SelectMultipleResultSets()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("select * from people; select top 1 * from people", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                await ReadQueryResults(reader);
                await reader.NextResultAsync(); //move to next result set
                await ReadQueryResults(reader);
                reader.Close();
            }
        }

        private static async Task ReadQueryResults(SqlDataReader reader)
        {
            while(await reader.ReadAsync())
            {
                string format = "Person ({0}) is named {1} {2}";
                if (reader["middlename"] == null)
                    Console.WriteLine(format, reader["firstname"], reader["lastname"]);
                else
                    Console.WriteLine(format, reader["firstname"], reader["lastname"]);
            }
        }
    }
}
