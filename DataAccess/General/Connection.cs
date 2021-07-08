using System;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Connection
    {
        /// <summary>
        /// Obtem a instancia da conexão.
        /// </summary>
        /// <returns>Retorna conexão aberta</returns>
        public static SqlConnection getConnection()
        {
            try
            {
                SqlConnection m_SqlConnection = null;
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "REDDRAGON\\SQLSERVER";
                builder.UserID = "sa";
                builder.Password = "aaxd31";
                builder.InitialCatalog = "TesteTTI";
                m_SqlConnection = new SqlConnection(builder.ConnectionString);
                return m_SqlConnection;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
