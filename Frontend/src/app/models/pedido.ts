export interface Pedido {
    id: number;
    client_id: string;
    total_pedido: number;
    produtos:PedidoProduto[];
}
export interface PedidoProduto {
    id: number;
    produto_id: string;
    pedido_id: number;
}
