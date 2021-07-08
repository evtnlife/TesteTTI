using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class ProdutoDAO
    {
        private int m_Id;
        private string m_Name;
        private decimal m_Price;
        private int m_CategoriaId;
        public ProdutoDAO(){}
        public ProdutoDAO(int id, string name, decimal price, int category)
        {
            m_Id = id;
            m_Name = name;
            m_Price = price;
            m_CategoriaId = category;
        }

        public int Id { get => m_Id; set => m_Id = value; }
        public string Name { get => m_Name; set => m_Name = value; }
        public decimal Price { get => m_Price; set => m_Price = value; }
        public int CategoriaId { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("ProdutoDAO: [ID:{0} | NAME: {1} | PRICE:{2} | Categoria:{3}]", Id, Name, Price, CategoriaId);
            return sb.ToString();
        }
    }
}
