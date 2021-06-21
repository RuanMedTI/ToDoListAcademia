using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToDoListAcademia.Controladores;
using ToDoListAcademia.Dominio;

namespace ToDoListAcademia.Test
{
    [TestClass]
    public class TesteDosContatos
    {
        public ControladorContatos controlador;
        public Contato contatoTeste;
        public TesteDosContatos()
        {
            controlador = new ControladorContatos();
            contatoTeste = new Contato("Teste", "emailteste@academia.net", "123412340", "Academia", "Desenvolvedor");
        }

        [TestMethod]
        public void DeveInserirUmNovoContato()
        {
            controlador.InserirNovoContato(contatoTeste);
        }

        [TestMethod]
        public void DeveAtualizarContato()
        {
            controlador.AtualizarContato(contatoTeste);
        }

        [TestMethod]
        public void DeveExcluirContato()
        {
            controlador.ExcluirContato(contatoTeste);
        }
    }
}
