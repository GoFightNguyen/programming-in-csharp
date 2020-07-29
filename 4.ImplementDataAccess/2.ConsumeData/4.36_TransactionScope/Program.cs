using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Transactions;

namespace _4._36_TransactionScope
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public async Task Transaction()
        {
            var connectionString = "don't want to look up";
            using (TransactionScope transactionScope = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    var command1 = new SqlCommand("Insert into people([FirstName], [LastName]) Values ('Jon', 'Doe'))", connection);
                    var command2 = new SqlCommand("Insert into people([FirstName], [LastName]) Values ('Jon2', 'Doe2'))", connection);

                    await command1.ExecuteNonQueryAsync();
                    await command2.ExecuteNonQueryAsync();
                }
                transactionScope.Complete();
            }
        }
    }
}
