SELECT P.nome AS NomeDoProduto, P.preco AS PrecoDoProduto
FROM Produtos P
JOIN Fornecedores F ON P.fornecedorID = F.id
WHERE F.nome = 'Fornecedor A';
