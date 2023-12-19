CREATE TABLE Fornecedores (
    id INT PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    endereco VARCHAR(255),
    telefone VARCHAR(20),
    email VARCHAR(255) UNIQUE
);

INSERT INTO Fornecedores (id, nome, endereco, telefone, email)
VALUES (1, 'Fornecedor A', 'Rua zelda, Nº 777', '2196655-3210', 'for01@email.com');


INSERT INTO Fornecedores (id, nome, endereco, telefone, email)
VALUES (2, 'Fornecedor B', 'Rua professor Carvalho, Nº 562', '212455-7784', 'for02@email.com');


INSERT INTO Fornecedores (id, nome, endereco, telefone, email)
VALUES (3, 'Fornecedor C', 'Rua Alan Wake, Nº 622', '212416-6237', 'for03@email.com');