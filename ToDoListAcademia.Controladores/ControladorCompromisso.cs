using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ToDoListAcademia.DB;
using ToDoListAcademia.Dominio;

namespace ToDoListAcademia.Controladores
{
    public class ControladorCompromisso
    {
        public void InserirNovoCompromisso(Compromisso compromisso)
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoInsercao = new SqlCommand();
            comandoInsercao.Connection = con;

            string sqlInsercao =
                @"INSERT INTO TBCOMPROMISSOS
                    (
                        [ASSUNTO],
                        [LOCAL],
                        [DATACOMPROMISSO],
                        [HORAINICIO],
                        [ID_CONTATO]
                    )
                    VALUES
                    (
                        @ASSUNTO,
                        @LOCAL,
                        @DATACOMPROMISSO,
                        @HORAINICIO,
                        @ID_CONTATO
                    );";

            sqlInsercao += @"SELECT SCOPE_IDENTITY();";

            comandoInsercao.CommandText = sqlInsercao;

            comandoInsercao.Parameters.AddWithValue("ASSUNTO", compromisso.Assunto);
            comandoInsercao.Parameters.AddWithValue("LOCAL", compromisso.Local);
            comandoInsercao.Parameters.AddWithValue("DATACOMPROMISSO", compromisso.DataCompromisso);
            comandoInsercao.Parameters.AddWithValue("HORAINICIO", compromisso.HoraInicio);

            if (compromisso.Id == null)
            {
                comandoInsercao.Parameters.AddWithValue("ID_CONTATO", DBNull.Value);
            }
            else
                comandoInsercao.Parameters.AddWithValue("ID_CONTATO", compromisso.Id);

            object id = comandoInsercao.ExecuteScalar();

            compromisso.Id = Convert.ToInt32(id);

            con.Close();
        }

        public void AtualizarCompromisso(Compromisso compromisso)
        {

            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoAtualizacao = new SqlCommand();
            comandoAtualizacao.Connection = con;

            string sqlAtualizacao =
                @"UPDATE TBCOMPROMISSOS
                    SET
                        [ASSUNTO] = @ASSUNTO,
                        [LOCAL] = @LOCAL,
                        [DATACOMPROMISSO] = @DATACOMPROMISSO,
                        [HORAINICIO] = @HORAINICIO,
                        [ID_CONTATO] = @ID_CONTATO
                    WHERE
                        [ID] = @ID";

            comandoAtualizacao.CommandText = sqlAtualizacao;

            comandoAtualizacao.Parameters.AddWithValue("ID", compromisso.Id);
            comandoAtualizacao.Parameters.AddWithValue("ASSUNTO", compromisso.Assunto);
            comandoAtualizacao.Parameters.AddWithValue("LOCAL", compromisso.Local);
            comandoAtualizacao.Parameters.AddWithValue("DATACOMPROMISSO", compromisso.DataCompromisso);
            comandoAtualizacao.Parameters.AddWithValue("HORAINICIO", compromisso.HoraInicio);

            comandoAtualizacao.ExecuteNonQuery();

            con.Close();
        }

        public void ExcluirCompromisso(Compromisso compromisso)
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoExclusao = new SqlCommand();
            comandoExclusao.Connection = con;

            string sqlExclusao =
                @"DELETE FROM TBCOMPROMISSOS	                
	                WHERE 
		                [ID] = @ID";

            comandoExclusao.CommandText = sqlExclusao;

            comandoExclusao.Parameters.AddWithValue("ID", compromisso.Id);

            comandoExclusao.ExecuteNonQuery();

            con.Close();
        }

        public Compromisso SelecionarCompromissoPorId(int idPesquisado)
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT 
                        [ID], 
                        [ASSUNTO], 
                        [LOCAL],
                        [DATACOMPROMISSO],
                        [DATATERMINO],
                        [HORAINICIO],
                        [ID_CONTATO]
                    FROM 
                        TBCOMPROMISSOS
                    WHERE 
                        ID = @ID";

            comandoSelecao.CommandText = sqlSelecao;
            comandoSelecao.Parameters.AddWithValue("ID", idPesquisado);

            SqlDataReader leitorCompromisso = comandoSelecao.ExecuteReader();

            if (leitorCompromisso.Read() == false)
                return null;

            int id = Convert.ToInt32(leitorCompromisso["ID"]);

            string assunto = Convert.ToString(leitorCompromisso["ASSUNTO"]);

            string local = Convert.ToString(leitorCompromisso["LOCAL"]);

            string horaInicio = Convert.ToString(leitorCompromisso["HORAINICIO"]);

            DateTime dataCompromisso = Convert.ToDateTime(leitorCompromisso["DATACOMPROMISSO"]);

            DateTime dataTermino = DateTime.MinValue;

            if (leitorCompromisso["DATATERMINO"] != DBNull.Value)
                dataTermino = Convert.ToDateTime(leitorCompromisso["DATATERMINO"]);

            Compromisso cp = new Compromisso(assunto, local, horaInicio, dataTermino, dataCompromisso);
            cp.Id = id;

            con.Close();

            return cp;
        }

        public List<Compromisso> SelecionarTodosOsCompromissos()
        {
            SqlConnection con = BancoDeDados.AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT 
                        ID, 
                        ASSUNTO, 
                        LOCAL, 
                        DATACOMPROMISSO,
                        HORAINICIO
                    FROM 
                        TBCOMPROMISSOS";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorCompromisso = comandoSelecao.ExecuteReader();

            List<Compromisso> compromissos = new List<Compromisso>();

            while (leitorCompromisso.Read())
            {
                int id = Convert.ToInt32(leitorCompromisso["ID"]);

                string assunto = Convert.ToString(leitorCompromisso["ASSUNTO"]);

                string local = Convert.ToString(leitorCompromisso["LOCAL"]);

                string horaInicio = Convert.ToString(leitorCompromisso["HORAINICIO"]);

                DateTime dataCompromisso = Convert.ToDateTime(leitorCompromisso["DATACOMPROMISSO"]);

                Compromisso compromisso = new Compromisso(assunto, local, horaInicio, dataCompromisso);

                compromisso.Id = id;

                compromissos.Add(compromisso);
            }

            con.Close();

            return compromissos;
        }
    }
}
