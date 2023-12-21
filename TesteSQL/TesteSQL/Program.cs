using System.Data.SqlClient;

namespace TesteSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");                       
            
            string connectionString = "Server=DESKTOP-8TA92CI;Database=TesteTJRJ;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string storedProcedureName = "ObterProdutosFornecedoresPorCliente";

                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@clienteId", 1);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader["NomeCliente"]);
                                Console.WriteLine(reader["NomeProduto"]);
                                Console.WriteLine(reader["PrecoProduto"]);
                                Console.WriteLine(reader["Quantidade"]);
                                Console.WriteLine(reader["NomeFornecedor"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro: " + ex.Message);
                    }
                }
            }
        }
    }
}