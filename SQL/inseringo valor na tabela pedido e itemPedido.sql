
INSERT INTO Pedidos(id, clienteID, data_pedido)
VALUES (1, 1, GETDATE());


INSERT INTO ItensPedido (id, pedidoID, produtoID, quantidade)
VALUES 
    (1, 1, 1, 15), 
    (2, 1, 2, 10);
