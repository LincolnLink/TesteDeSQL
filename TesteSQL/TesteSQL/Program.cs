using System.Data.SqlClient;

namespace TesteSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");                       

            // Substitua a string de conexão pelos seus próprios detalhes de conexão.
            string connectionString = "Server=DESKTOP-8TA92CI;Database=TesteTJRJ;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Nome da sua stored procedure
                string storedProcedureName = "ObterProdutosFornecedoresPorCliente";

                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    // Defina o tipo do comando como stored procedure
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Adicione parâmetros, se necessário
                    command.Parameters.AddWithValue("@clienteId", 1);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Processar os resultados aqui
                                // Exemplo:
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