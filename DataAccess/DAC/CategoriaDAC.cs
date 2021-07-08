using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    public class CategoriaDAC
    {
        public List<CategoriaDAO> GetAll()
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
                            List<CategoriaDAO> categoria = new List<CategoriaDAO>();
                            while (reader.Read())
                                categoria.Add(GetDAO(reader));
                            if (categoria.Count > 0)
                                return categoria;
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
        private CategoriaDAO GetDAO(SqlDataReader reader)
        {
            CategoriaDAO dao = new CategoriaDAO();
            if (!reader.IsDBNull(0)) dao.Id = reader.GetInt32(0);
            if (!reader.IsDBNull(1)) dao.Name = reader.GetString(1);
            return dao;
        }
    }
}
