using System;
using System.Collections.Generic;
using ToDoListAcademia.Controladores;

namespace ToDoListAcademia.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ControladorLista controladorLista = new ControladorLista();
            ControladorContatos controladorContatos = new ControladorContatos();
            ControladorCompromisso controladorCompromisso = new ControladorCompromisso();

            TelaLista telaLista = new TelaLista(controladorLista);
            TelaContatos telaContatos = new TelaContatos(controladorContatos);
            TelaCompromisso telaCompromisso = new TelaCompromisso(controladorCompromisso);

            string opcao = "";

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Academia do Programador DataBase 1.1");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\nMenu Lista");

            Console.WriteLine("Digite 1 para Cadastrar Tarefa na Lista");
            Console.WriteLine("Digite 2 para Ataulizar Tarefa na Lista");
            Console.WriteLine("Digite 3 para Excluir Tarefa na Lista");
            Console.WriteLine("Digite 4 para Visualizar Tarefa em Aberto na Lista");
            Console.WriteLine("Digite 5 para Visualizar Tarefa Concluídas na Lista");

            Console.WriteLine("\nMenu Contatos");

            Console.WriteLine("Digite 6 para Cadastrar Contato");
            Console.WriteLine("Digite 7 para Editar Contato");
            Console.WriteLine("Digite 8 para Excluir Contato");
            Console.WriteLine("Digite 9 para Visualizar Contatos");

            Console.WriteLine("\nMenu Compromissos");

            Console.WriteLine("Digite 10 para Cadastrar Compromisso");
            Console.WriteLine("Digite 11 para Editar Compromisso");
            Console.WriteLine("Digite 12 para Excluir Compromisso");
            Console.WriteLine("Digite 13 para Visualizar Compromissos");
            Console.WriteLine("Digite 14 para Visualizar Compromissos Entre Datas");

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Digite S para Sair");
            Console.ResetColor();

            opcao = Console.ReadLine();

            if (opcao == "1")
            {
                if (opcao == "1")
                    telaLista.CadastrarNovaTarefa();
            }
            if (opcao == "2")
            {
                if (opcao == "2")
                    telaLista.AtualizarTarefa();
            }
            if (opcao == "3")
            {
                if (opcao == "3")
                    telaLista.ExcluirTarefa();
            }
            if (opcao == "4")
            {
                if (opcao == "4")
                    telaLista.VisualizarTarefasEmAberto();
            }
            if (opcao == "5")
            {
                if (opcao == "5")
                    telaLista.VisualizarTarefasConcluidas();
            }


            if (opcao == "6")
            {
                if (opcao == "6")
                    telaContatos.CadastrarNovoContato();
            }
            if (opcao == "7")
            {
                if (opcao == "7")
                    telaContatos.AtualizarContato();
            }
            if (opcao == "8")
            {
                if (opcao == "8")
                    telaContatos.ExcluirContato();
            }
            if (opcao == "9")
            {
                if (opcao == "9")
                    telaContatos.VisualizarTodosOsContatos();
            }

            if (opcao == "10")
            {
                if (opcao == "10")
                    telaCompromisso.CadastrarNovoCompromisso();
            }
            if (opcao == "11")
            {
                if (opcao == "11")
                    telaCompromisso.AtualizarCompromisso();
            }
            if (opcao == "12")
            {
                if (opcao == "12")
                    telaCompromisso.ExcluirCompromisso();
            }
            if (opcao == "13")
            {
                if (opcao == "13")
                    telaCompromisso.VisualizarTodosOsCompromissos();
            }
            if (opcao == "14")
            {
                if (opcao == "14")
                    telaCompromisso.VisualizarCompromissosEntreDatas();
            }
        }
    }
}








