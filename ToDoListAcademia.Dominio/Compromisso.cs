using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAcademia.Dominio
{
    public class Compromisso : DominioBase
    {
        public string Assunto;
        public string Local;
        public string HoraInicio;
        public DateTime DataCompromisso;
        public DateTime DataTermino;

        public Compromisso(string assunto, string local, string horaInicio, DateTime dataCompromisso)
        {
            Assunto = assunto;
            Local = local;
            HoraInicio = horaInicio;
            DataCompromisso = dataCompromisso;
        }

        public Compromisso(string assunto, string local, string horaInicio, DateTime dataCompromisso,
            DateTime dataTermino)
        {
            Assunto = assunto;
            Local = local;
            HoraInicio = horaInicio;
            DataCompromisso = dataCompromisso;
            DataTermino = dataTermino;
        }
    }
}
