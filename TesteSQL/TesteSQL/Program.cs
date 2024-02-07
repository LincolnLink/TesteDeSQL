using System.Data.SqlClient;
using System;
using Oracle.ManagedDataAccess.Client;
using System.Reflection.PortableExecutable;

namespace TesteSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string connectionString = "Data Source=localhost/XEPDB1;User Id=ADMIN;Password=admin123;";

            // Nome da procedure que você quer chamar
            string procedureName = "OBTERPRODUTOSFORNECEDORESPORCLIENTE";

            // Valor para o parâmetro da procedure (se houver)
            int clienteId = 1; // Exemplo de valor de parâmetro

            // Lista para armazenar os resultados da procedure
            List<ProdutoFornecedor> produtosFornecedores = new List<ProdutoFornecedor>();

            // String para armazenar os resultados da procedure
            //string resultString = "";

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexão bem-sucedida!");

                    // Aqui você pode realizar operações no banco de dados, como executar consultas, inserções, etc.

                    // Cria um comando para chamar a procedure
                    using (OracleCommand command = new OracleCommand(procedureName, connection))
                    {
                        // Define o tipo do comando como procedure
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Adiciona parâmetros (se necessário)
                        command.Parameters.Add("clienteId", OracleDbType.Int32).Value = clienteId;

                        // Adiciona parâmetro de saída para o cursor
                        command.Parameters.Add("resultado", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;


                        // Executa o comando
                        // command.ExecuteNonQuery();

                        // Cria um reader para ler os resultados da procedure
                        using (OracleDataReader reader = command.ExecuteReader())
                        {

                            // Verifica se o reader tem linhas para ler
                            if (reader.HasRows)
                            {
                                // Itera sobre as linhas do resultado
                                while (reader.Read())
                                {
                                    // Cria um novo objeto ProdutoFornecedor e atribui os valores das colunas
                                    ProdutoFornecedor produtoFornecedor = new ProdutoFornecedor();
                                    produtoFornecedor.NomeCliente = reader["NomeCliente"].ToString();
                                    produtoFornecedor.NomeProduto = reader["NomeProduto"].ToString();
                                    produtoFornecedor.PrecoProduto = Convert.ToDecimal(reader["PrecoProduto"]);
                                    produtoFornecedor.Quantidade = Convert.ToInt32(reader["Quantidade"]);
                                    produtoFornecedor.NomeFornecedor = reader["NomeFornecedor"].ToString();

                                    // Adiciona o objeto à lista
                                    produtosFornecedores.Add(produtoFornecedor);


                                    // Aqui você pode processar os dados retornados
                                    // Exemplo de leitura de uma coluna:
                                    //string nomeCliente = reader["NomeCliente"].ToString();
                                    //Console.WriteLine("Nome do Cliente: " + nomeCliente);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nenhum resultado retornado pela procedure.");
                            }

                            //while (reader.Read())
                            //{
                            //    // Concatena os valores das colunas em uma única string, separados por uma vírgula
                            //    for (int i = 0; i < reader.FieldCount; i++)
                            //    {
                            //        resultString += reader[i].ToString() + ",";
                            //    }
                            //}

                            // Verifica se o reader tem linhas para ler
                            //if (reader.HasRows)
                            //{
                            //    // Inicializa o array com o número de colunas retornadas pela procedure
                            //    results = new object[reader.FieldCount];

                            //    // Lê os valores retornados pela procedure e os armazena no array
                            //    while (reader.Read())
                            //    {
                            //        reader.GetValues(results);
                            //    }

                            //    while (reader.Read())
                            //    {
                            //        Console.WriteLine(reader["NomeCliente"]);
                            //        Console.WriteLine(reader["NomeProduto"]);
                            //        Console.WriteLine(reader["PrecoProduto"]);
                            //        Console.WriteLine(reader["Quantidade"]);
                            //        Console.WriteLine(reader["NomeFornecedor"]);
                            //    }
                            //}
                        }                       

                        Console.WriteLine("Procedure executada com sucesso!");
                       
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
                }

                // Exibe os valores armazenados nos objetos ProdutoFornecedor
                foreach (var produtoFornecedor in produtosFornecedores)
                {
                    Console.WriteLine($"Nome do Cliente: {produtoFornecedor.NomeCliente}");
                    Console.WriteLine($"Nome do Produto: {produtoFornecedor.NomeProduto}");
                    Console.WriteLine($"Preço do Produto: {produtoFornecedor.PrecoProduto}");
                    Console.WriteLine($"Quantidade: {produtoFornecedor.Quantidade}");
                    Console.WriteLine($"Nome do Fornecedor: {produtoFornecedor.NomeFornecedor}");
                    Console.WriteLine();
                }


                // Remove a última vírgula da string, se houver
                //if (!string.IsNullOrEmpty(resultString))
                //{
                //    resultString = resultString.TrimEnd(',');
                //}

                //// Exibe a string com os valores retornados pela procedure
                //Console.WriteLine("Valores retornados pela procedure: " + resultString);

            }

            //codigo para o SQLSERVER

            /**
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
            }**/
        }
    }

    public class ProdutoFornecedor
    {
        public string NomeCliente { get; set; }
        public string NomeProduto { get; set; }
        public decimal PrecoProduto { get; set; }
        public int Quantidade { get; set; }
        public string NomeFornecedor { get; set; }
    }

}