using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    public class ClienteDAC
    {
        public List<ClienteDAO> GetAll()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                using (SqlConnection connection = Connection.getConnection())
                {
                    connection.Open();
                    sb.Append("select * from Clientes;");

                    using (SqlCommand command = new SqlCommand(sb.ToString(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<ClienteDAO> cliente = new List<ClienteDAO>();
                            while (reader.Read())
                                cliente.Add(GetDAO(reader));
                            if (cliente.Count > 0)
                                return cliente;
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Converte objeto reader parar dao
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>Retorna um produto</returns>
        private ClienteDAO GetDAO(SqlDataReader reader)
        {
            ClienteDAO dao = new ClienteDAO();
            if (!reader.IsDBNull(0)) dao.Id = reader.GetInt32(0);
            if (!reader.IsDBNull(1)) dao.Name = reader.GetString(1);
            if (!reader.IsDBNull(2)) dao.Phone = reader.GetString(2);
            return dao;
        }
    }
}
