CREATE PROCEDURE ObterProdutosFornecedoresPorCliente
    @clienteId INT
AS
BEGIN
    SELECT C.nome AS NomeCliente, P.nome AS NomeProduto, 
	P.preco AS PrecoProduto, 
	IP.quantidade AS Quantidade,
	F.nome AS NomeFornecedor	
    FROM Clientes C
    JOIN Pedidos PD ON C.id = PD.clienteID
    JOIN ItensPedido IP ON PD.id = IP.pedidoID
    JOIN Produtos P ON IP.produtoID = P.id
    JOIN Fornecedores F ON P.fornecedorID = F.id
    WHERE C.id = @clienteId; -- usa o valor 1 caso tenha botado os valores dos codigos.
END;
