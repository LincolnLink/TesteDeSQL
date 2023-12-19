CREATE TABLE Pedidos (
    id INT PRIMARY KEY,
    clienteID INT,
    data_pedido DATE NOT NULL,
    FOREIGN KEY (clienteID) REFERENCES Clientes(id)
);

CREATE TABLE ItensPedido (
    id INT PRIMARY KEY,
    pedidoID INT,
    produtoID INT,
    quantidade INT NOT NULL,
    FOREIGN KEY (pedidoID) REFERENCES Pedidos(id),
    FOREIGN KEY (produtoID) REFERENCES Produtos(id)
);

