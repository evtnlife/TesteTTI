using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class PedidoProdutoDAO
    {
        private int m_Id;
        private int m_ProdutoId;
        private int m_PedidoId;
        public PedidoProdutoDAO() { }
        public PedidoProdutoDAO(int id, int produto, int pedido)
        {
            m_Id = id;
            m_ProdutoId = produto;
            m_PedidoId = pedido;
        }

        public int Id { get => m_Id; set => m_Id = value; }
        public int ProdutoId { get => m_ProdutoId; set => m_ProdutoId= value; }
        public int PedidoId { get => m_PedidoId; set => m_PedidoId= value; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("PedidoProduto: [ID:{0} | ProdutoId: {1} | PedidoId:{2} ]", Id, ProdutoId, PedidoId);
            return sb.ToString();
        }
    }
}
