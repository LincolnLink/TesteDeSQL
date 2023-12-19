CREATE TABLE Clientes (
    id INT PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    endereco VARCHAR(255),
    telefone VARCHAR(20),
    data_nascimento DATE
);

INSERT INTO Clientes (id, nome, endereco, telefone, data_nascimento)
VALUES (1, 'João Carlos', 'rua rio de flores', '1456-7890', '1990-01-01');

INSERT INTO Clientes (id, nome, endereco, telefone, data_nascimento)
VALUES (2, 'Amanda Clara', 'av do Barbeiro', '1456-7890', '1980-02-02');


INSERT INTO Clientes (id, nome, endereco, telefone, data_nascimento)
VALUES (3, 'Carlos Henrique', 'av Brasil 562', '2416-4490', '2000-01-01');
