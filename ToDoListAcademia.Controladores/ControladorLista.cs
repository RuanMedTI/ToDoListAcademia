using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ToDoListAcademia;
using ToDoListAcademia.DB;
using ToDoListAcademia.Dominio;

namespace ToDoListAcademia.Controladores
{
    public class ControladorLista
    {
        public void InserirNovaLista(Lista lista)
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoInsercao = new SqlCommand();
            comandoInsercao.Connection = con;

            string sqlInsercao =
                @"INSERT INTO TBLISTA
                    (
                        [TITULO],
                        [DATACRIACAO],
                        [PRIORIDADE]
                    )
                    VALUES
                    (
                        @TITULO,
                        @DATACRIACAO,
                        @PRIORIDADE
                    );";

            sqlInsercao += @"SELECT SCOPE_IDENTITY();";

            comandoInsercao.CommandText = sqlInsercao;

            comandoInsercao.Parameters.AddWithValue("TITULO", lista.Titulo);
            comandoInsercao.Parameters.AddWithValue("DATACRIACAO", lista.DataCriacao);
            comandoInsercao.Parameters.AddWithValue("PRIORIDADE", lista.Prioridade);

            object id = comandoInsercao.ExecuteScalar();

            lista.Id = Convert.ToInt32(id);

            con.Close();
        }

        public void AtualizarTarefa(Lista lista)
        {

            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoAtualizacao = new SqlCommand();
            comandoAtualizacao.Connection = con;

            string sqlAtualizacao =
                @"UPDATE TBLISTA
                    SET
                        [TITULO] = @TITULO,
                        [DATACONCLUSAO] = @DATACONCLUSAO,
                        [PRIORIDADE] = @PRIORIDADE
                    WHERE
                        [ID] = @ID";

            comandoAtualizacao.CommandText = sqlAtualizacao;

            comandoAtualizacao.Parameters.AddWithValue("ID", lista.Id);
            comandoAtualizacao.Parameters.AddWithValue("TITULO", lista.Titulo);
            comandoAtualizacao.Parameters.AddWithValue("DATACONCLUSAO", lista.DataConclusao);
            comandoAtualizacao.Parameters.AddWithValue("PRIORIDADE", lista.Prioridade);

            comandoAtualizacao.ExecuteNonQuery();

            con.Close();
        }

        public void ExcluirTarefa(Lista lista)
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoExclusao = new SqlCommand();
            comandoExclusao.Connection = con;

            string sqlExclusao =
                @"DELETE FROM TBLISTA	                
	                WHERE 
		                [ID] = @ID";

            comandoExclusao.CommandText = sqlExclusao;

            comandoExclusao.Parameters.AddWithValue("ID", lista.Id);

            comandoExclusao.ExecuteNonQuery();

            con.Close();
        }

        public Lista SelecionarTarefaPorId(int idPesquisado)
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT 
                        [ID], 
                        [TITULO], 
                        [DATACRIACAO],
                        [DATACONCLUSAO],
                        [PRIORIDADE]
                    FROM 
                        TBTAREFA
                    WHERE 
                        ID = @ID";

            comandoSelecao.CommandText = sqlSelecao;
            comandoSelecao.Parameters.AddWithValue("ID", idPesquisado);

            SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader();

            if (leitorTarefas.Read() == false)
                return null;

            int id = Convert.ToInt32(leitorTarefas["ID"]);

            string titulo = Convert.ToString(leitorTarefas["TITULO"]);

            DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);

            DateTime dataConclusao = DateTime.MinValue;

            if (leitorTarefas["DATACONCLUSAO"] != DBNull.Value)
                dataConclusao = Convert.ToDateTime(leitorTarefas["DATACONCLUSAO"]);

            int prioridade = Convert.ToInt32(leitorTarefas["PRIORIDADE"]);

            Lista l = new Lista(titulo, dataCriacao, dataConclusao, prioridade);
            l.Id = id;

            con.Close();

            return l;
        }

        public List<Lista> SelecionarTodasAsTarefas()
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT 
                        [ID], 
                        [TITULO], 
                        [DATACRIACAO], 
                        [PRIORIDADE] 
                    FROM 
                        TBTAREFA
                    ORDER BY 
                        [PRIORIDADE] ASC";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader();

            List<Lista> tarefas = new List<Lista>();

            while (leitorTarefas.Read())
            {
                int id = Convert.ToInt32(leitorTarefas["ID"]);

                string titulo = Convert.ToString(leitorTarefas["TITULO"]);

                DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);

                int prioridade = Convert.ToInt32(leitorTarefas["PRIORIDADE"]);

                Lista tarefa = new Lista(titulo, dataCriacao, prioridade);

                tarefa.Id = id;

                tarefas.Add(tarefa);
            }

            con.Close();

            return tarefas;
        }

        public List<Lista> SelecionarTodasAsTarefasEmAberto()
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT 
                        [ID], 
                        [TITULO], 
                        [DATACRIACAO], 
                        [PRIORIDADE] 
                    FROM 
                        TBLISTA";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader();

            List<Lista> tarefas = new List<Lista>();

            while (leitorTarefas.Read())
            {
                int id = Convert.ToInt32(leitorTarefas["ID"]);

                if (leitorTarefas["ID"] != DBNull.Value)
                    id = Convert.ToInt32(leitorTarefas["ID"]);

                string titulo = Convert.ToString(leitorTarefas["TITULO"]);

                DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);

                int prioridade = Convert.ToInt32(leitorTarefas["PRIORIDADE"]);

                Lista tarefa = new Lista(titulo, dataCriacao, prioridade);

                tarefa.Id = id;

                tarefas.Add(tarefa);
            }

            con.Close();

            return tarefas;
        }

        public List<Lista> SelecionarTodasAsTarefasConcluidas()
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT 
                        [ID], 
                        [TITULO], 
                        [DATACRIACAO],
                        [DATACONCLUSAO],
                        [PRIORIDADE] 
                    FROM 
                        TBTAREFA
                    WHERE
                        PERCENTUAL = '100%'
                    ORDER BY
                        [PRIORIDADE] ASC, [DATACRIACAO]";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader();

            List<Lista> tarefasConcluidas = new List<Lista>();

            while (leitorTarefas.Read())
            {
                int id = Convert.ToInt32(leitorTarefas["ID"]);

                string titulo = Convert.ToString(leitorTarefas["TITULO"]);

                DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);

                DateTime dataConclusao = Convert.ToDateTime(leitorTarefas["DATACONCLUSAO"]);

                int prioridade = Convert.ToInt32(leitorTarefas["PRIORIDADE"]);

                Lista lista = new Lista(titulo, dataCriacao, dataConclusao, prioridade);
                lista.Id = id;

                tarefasConcluidas.Add(lista);
            }

            con.Close();

            return tarefasConcluidas;
        }
    }
}
