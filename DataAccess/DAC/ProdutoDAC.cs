using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProdutoDAC
    {
        public async Task<int> Insert(ProdutoDAO dao)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                using (SqlConnection connection = Connection.getConnection())
                {
                    await connection.OpenAsync();
                    sb.Append("INSERT INTO PRODUTOS (name, price, categoria_id) VALUES (@name, @price, @categoria);");
                    using (SqlCommand command = new SqlCommand(sb.ToString(), connection))
                    {
                        command.Parameters.Add(new SqlParameter("name", dao.Name));
                        command.Parameters.Add(new SqlParameter("price", dao.Price));
                        command.Parameters.Add(new SqlParameter("categoria", dao.CategoriaId));
                        int value = await command.ExecuteNonQueryAsync();
                        if (value <= 0)
                            throw new Exception("Erro na inserção de registro na tabela.");
                        return value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Object> Update(ProdutoDAO dao)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                using (SqlConnection connection = Connection.getConnection())
                {
                    await connection.OpenAsync();
                    sb.Append("UPDATE PRODUTOS SET name = @name, price = @price, categoria_id = @categoria where id = @id");

                    using (SqlCommand command = new SqlCommand(sb.ToString(), connection))
                    {
                        command.Parameters.Add(new SqlParameter("name", dao.Name));
                        command.Parameters.Add(new SqlParameter("price", dao.Price));
                        command.Parameters.Add(new SqlParameter("categoria", dao.CategoriaId));
                        command.Parameters.Add(new SqlParameter("id", dao.Id));
                        var value = await command.ExecuteNonQueryAsync();
                        if (value <= 0)
                            throw new Exception("Erro na atualização de registro na tabela.");
                        return value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> Delete(ProdutoDAO dao)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                using (SqlConnection connection = Connection.getConnection())
                {
                    await connection.OpenAsync();
                    sb.Append("DELETE FROM PRODUTOS where id = @id");

                    using (SqlCommand command = new SqlCommand(sb.ToString(), connection))
                    {
                        command.Parameters.Add(new SqlParameter("id", dao.Id));
                        var value = await command.ExecuteNonQueryAsync();
                        if (value == 0)
                            throw new Exception("Erro na atualização de registro na tabela.");
                        return value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ProdutoDAO> GetAll()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                using (SqlConnection connection = Connection.getConnection())
                {
                    connection.Open();
                    sb.Append("select * from PRODUTOS;");

                    using (SqlCommand command = new SqlCommand(sb.ToString(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<ProdutoDAO> produtos = new List<ProdutoDAO>();
                            while (reader.Read())
                                produtos.Add(GetDAO(reader));
                            if (produtos.Count > 0)
                                return produtos;
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
        private ProdutoDAO GetDAO(SqlDataReader reader) 
        {
            ProdutoDAO dao = new ProdutoDAO();
            if (!reader.IsDBNull(0)) dao.Id = reader.GetInt32(0);
            if (!reader.IsDBNull(1)) dao.Name = reader.GetString(1);
            if (!reader.IsDBNull(2)) dao.Price = reader.GetDecimal(2);
            if (!reader.IsDBNull(3)) dao.CategoriaId = reader.GetInt32(3);
            return dao;
        }
    }
}
