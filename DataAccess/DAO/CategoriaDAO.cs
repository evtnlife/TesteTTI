using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class CategoriaDAO
    {
        private int m_Id;
        private string m_Name;
        public CategoriaDAO() { }
        public CategoriaDAO(int id, string name)
        {
            m_Id = id;
            m_Name = name;
        }

        public int Id { get => m_Id; set => m_Id = value; }
        public string Name { get => m_Name; set => m_Name = value; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("ProdutoDAO: [ID:{0} | NAME: {1}]", Id, Name);
            return sb.ToString();
        }
    }
}
