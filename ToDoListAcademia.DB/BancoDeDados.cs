using System;
using System.Data.SqlClient;

namespace ToDoListAcademia.DB
{
    public static class BancoDeDados
    {
        private static string enderecoDBLista =
            @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=DBLista;Integrated Security=True;Pooling=False";

        public static SqlConnection AbrirConexao()
        {
            SqlConnection conexao = new SqlConnection();
            try
            {
                conexao.ConnectionString = enderecoDBLista;
                conexao.Open();
            }
            catch (Exception ex)
            {
                conexao.Close();
                throw new Exception(ex.Message);
            }

            return conexao;
        }
    }
}
