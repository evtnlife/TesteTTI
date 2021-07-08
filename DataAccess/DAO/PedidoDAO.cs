using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class PedidoDAO
    {
        private int m_Id;
        private int m_ClientId;
        private decimal m_TotalPedido;
        public PedidoDAO() { }
        public PedidoDAO(int id, int cliente, decimal total)
        {
            m_Id = id;
            m_ClientId = cliente;
            m_TotalPedido = total;
        }

        public int Id { get => m_Id; set => m_Id = value; }
        public int ClientId { get => m_ClientId; set => m_ClientId = value; }
        public decimal TotalPedido { get => m_TotalPedido; set => m_TotalPedido = value; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Pedido: [ID:{0} | ClienteID: {1} | TotalPedido:{2} ]", Id, ClientId, TotalPedido);
            return sb.ToString();
        }
    }
}
