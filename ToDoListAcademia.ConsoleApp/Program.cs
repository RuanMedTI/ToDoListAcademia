using System;
using System.Collections.Generic;
using ToDoListAcademia.Controladores;

namespace ToDoListAcademia.ConsoleApp
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            ControladorLista controlador = new ControladorLista();
            ControladorContatos controlador1 = new ControladorContatos();
            TelaLista telaLista = new TelaLista(controlador);
            TelaContatos telaContatos = new TelaContatos(controlador1);

            string opcao = "";

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Academia do Programador DataBase 1.1");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Digite 1 para o menu Lista");
            Console.WriteLine("Digite 2 para o menu Contatos");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Digite S para Sair");
            Console.ResetColor();

            opcao = Console.ReadLine();

            if (opcao == "1")
            {
                while (true)
                {
                    telaLista.ObterOpcao();

                    if (Console.ReadLine().Equals("s", StringComparison.OrdinalIgnoreCase))
                        break;

                    if (opcao == "1")
                        telaLista.CadastrarNovaTarefa();

                    if (opcao == "2")
                        telaLista.AtualizarTarefa();

                    if (opcao == "3")
                        telaLista.ExcluirTarefa();

                    if (opcao == "4")
                        telaLista.VisualizarTarefasEmAberto();

                    if (opcao == "5")
                        telaLista.VisualizarTarefasConcluidas();
                }
            }

            if (opcao == "2")
            {
                while (true)
                {
                    telaContatos.ObterOpcao();

                    if (Console.ReadLine().Equals("s", StringComparison.OrdinalIgnoreCase))
                        break;

                    if (opcao == "1")
                        telaContatos.CadastrarNovoContato();

                    if (opcao == "2")
                        telaContatos.AtualizarContato();

                    if (opcao == "3")
                        telaContatos.ExcluirContato();

                    if (opcao == "4")
                        telaContatos.VisualizarTodosOsContatos();
                }
            }  
        } 
    }
}







