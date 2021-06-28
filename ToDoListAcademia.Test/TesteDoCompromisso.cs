using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToDoListAcademia.Controladores;
using ToDoListAcademia.Dominio;

namespace ToDoListAcademia.Test
{
    [TestClass]
    public class TesteDoCompromisso
    {
        public ControladorCompromisso controlador;
        public Compromisso compromissoTeste;
        public TesteDoCompromisso()
        {
            controlador = new ControladorCompromisso();
            compromissoTeste = new Compromisso("Teste", "teste teste", "testeee", new DateTime(2021, 06, 21));
        }

        [TestMethod]
        public void DeveInserirUmNovoCompromisso()
        {
            controlador.InserirNovoCompromisso(compromissoTeste);
        }

        [TestMethod]
        public void DeveAtualizarCompromisso()
        {
            controlador.AtualizarCompromisso(compromissoTeste);
        }

        [TestMethod]
        public void DeveExcluirCompromisso()
        {
            controlador.ExcluirCompromisso(compromissoTeste);
        }
    }
}
