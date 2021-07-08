using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class ClienteDAO
    {
        private int m_Id;
        private string m_Name;
        private string m_Phone;
        public ClienteDAO() { }
        public ClienteDAO(int id, string name, string phone)
        {
            m_Id = id;
            m_Name = name;
            m_Phone = phone;
        }

        public int Id { get => m_Id; set => m_Id = value; }
        public string Name { get => m_Name; set => m_Name = value; }
        public string Phone { get => m_Phone; set => m_Phone = value; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Cliente: [ID:{0} | NAME: {1} | Phone:{2} ]", Id, Name, Phone);
            return sb.ToString();
        }
    }
}
