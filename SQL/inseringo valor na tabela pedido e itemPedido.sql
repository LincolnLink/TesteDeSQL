-- Inserir um novo pedido
INSERT INTO Pedidos(id, clienteID, data_pedido)
VALUES (1, 1, GETDATE()); -- Supondo que o ID do cliente seja 1 e a data atual seja usada

-- Inserir itens no pedido
INSERT INTO ItensPedido (id, pedidoID, produtoID, quantidade)
VALUES 
    (1, 1, 1, 15),  -- Supondo que o ID do produto seja 1 e a quantidade seja 2
    (2, 1, 2, 10);  -- Supondo que o ID do produto seja 2 e a quantidade seja 3
