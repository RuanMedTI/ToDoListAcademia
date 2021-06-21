using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAcademia.Dominio
{
    public class Lista : DominioBase
    {
        public string Titulo;
        public DateTime DataCriacao;
        public DateTime DataConclusao;
        public int Prioridade;

        public Lista(string titulo, DateTime dataCriacao, int prioridade)
        {
            Titulo = titulo;
            DataCriacao = dataCriacao;
            Prioridade = prioridade;
        }

        public Lista(string titulo, DateTime dataCriacao, DateTime dataConclusao,
            int prioridade)
        {
            Titulo = titulo;
            DataCriacao = dataCriacao;
            DataConclusao = dataConclusao;
            Prioridade = prioridade;
        }
    }
}
