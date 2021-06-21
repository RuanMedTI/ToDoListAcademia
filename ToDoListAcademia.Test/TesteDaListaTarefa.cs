using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToDoListAcademia.Controladores;
using ToDoListAcademia.Dominio;

namespace ToDoListAcademia.Test
{
    [TestClass]
    public class TesteDaListaTarefa
    {
        public ControladorLista controlador;
        public Lista listaTeste;
        public TesteDaListaTarefa()
        {
            controlador = new ControladorLista();
            listaTeste = new Lista("Testeprimario", new DateTime(2021, 06, 21), 1);
        }

        [TestMethod]
        public void DeveInserirUmaTarefaNova()
        {
            controlador.InserirNovaLista(listaTeste);
        }

        [TestMethod]
        public void DeveExcluirUmaTarefa()
        {
            controlador.ExcluirTarefa(listaTeste);
        }

    }
}
