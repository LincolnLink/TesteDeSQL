CREATE TABLE Produtos (
    id INT PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    preco DECIMAL(10, 2) NOT NULL,
    quantidade INT NOT NULL,
    fornecedorID INT,
    FOREIGN KEY (fornecedorID) REFERENCES Fornecedores(id)
);


INSERT INTO Produtos (id, nome, preco, quantidade, fornecedorID)
VALUES (1, 'Biscoito de chocolate wafer Bauducco', 6.99, 50, 1);


INSERT INTO Produtos (id, nome, preco, quantidade, fornecedorID)
VALUES (2, 'Biscoito de morango trakinas', 7.99, 50, 1);


INSERT INTO Produtos (id, nome, preco, quantidade, fornecedorID)
VALUES (3, 'Biscoito Maizena Marilan', 5.99, 50, 2);



INSERT INTO Produtos (id, nome, preco, quantidade, fornecedorID)
VALUES (4, 'Arroz tio João 1kg', 7.99, 50, 1);


INSERT INTO Produtos (id, nome, preco, quantidade, fornecedorID)
VALUES (5, 'Feijão carioca Camil 1kg', 17.99, 50, 1);


INSERT INTO Produtos (id, nome, preco, quantidade, fornecedorID)
VALUES (6, 'Macarrão Espaguete Santa Amália Sêmola 1Kg', 9.99, 50, 3);
