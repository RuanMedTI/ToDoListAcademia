using System;
using System.Collections.Generic;
using ToDoListAcademia.Controladores;
using ToDoListAcademia.Dominio;

namespace ToDoListAcademia.ConsoleApp
{
    public class TelaCompromisso : Tela<Compromisso>
    {
        private readonly ControladorCompromisso controlador;
        public TelaCompromisso(ControladorCompromisso ctrl) : base("Gerenciador de Compromissos Academia")
        {
            controlador = ctrl;
        }

        public void CadastrarNovoCompromisso()
        {
            ConfigurarTela("Cadastrando uma novo compromisso...");

            Console.Write("Digite o Assunto do Compromisso: ");
            string assunto = Console.ReadLine();

            Console.Write("Digite o Local do Compromisso (ou LINK do Meet): ");
            string local = Console.ReadLine();

            Console.Write("Digite a Hora do Compromisso (Extenso): ");
            string horaInicio = Console.ReadLine();

            Console.Write("Digite a data do Compromisso: ");
            DateTime dataCompromisso = Convert.ToDateTime(Console.ReadLine());

            controlador.InserirNovoCompromisso(new Compromisso(assunto, local, horaInicio, dataCompromisso));

            ApresentarMensagem("Compromisso cadastrado com sucesso!", Mensagem.Sucesso);
        }

        public void AtualizarCompromisso()
        {
            ConfigurarTela("Atualizando um compromisso...");

            VisualizarTodosOsCompromissos();

            Console.Write("\nDigite o ID do compromisso que deseja atualizar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Compromisso compromisso = controlador.SelecionarCompromissoPorId(id);

            Console.Write("Digite o Assunto do Compromisso: ");
            compromisso.Assunto = Console.ReadLine();

            Console.Write("Digite o Local do Compromisso (ou LINK do Meet): ");
            compromisso.Local = Console.ReadLine();

            Console.Write("Digite a Hora do Compromisso: ");
            compromisso.HoraInicio = Console.ReadLine();

            controlador.AtualizarCompromisso(compromisso);

            ApresentarMensagem("Compromisso atualizado com sucesso!", Mensagem.Sucesso);
        }

        public void ExcluirCompromisso()
        {
            ConfigurarTela("Excluindo um compromisso...");

            VisualizarTodosOsCompromissos();

            Console.Write("\nDigite o ID do Compromisso que deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Compromisso l = controlador.SelecionarCompromissoPorId(id);

            controlador.ExcluirCompromisso(l);

            ApresentarMensagem("Compromisso excluída sucesso!", Mensagem.Sucesso);
        }

        public void VisualizarTodosOsCompromissos()
        {
            ConfigurarTela("Visualizando todos os compromissos...");

            List<Compromisso> compromissos = controlador.SelecionarTodosOsCompromissos();

            if (ListaVazia(compromissos))
            {
                ApresentarMensagem("Nenhum Compromisso cadastrado!", Mensagem.Atencao);
                return;
            }

            string configuracaColunasTabela = "{0,-5} | {1,-25} | {2,-22} | {3,-3} | {4, -10}";

            MontarCabecalhoTabela(configuracaColunasTabela, "Id", "Assunto", "Local", "Hora", "Data Compromisso");

            foreach (Compromisso compromisso in compromissos)
            {
                Console.WriteLine(configuracaColunasTabela, compromisso.Id, compromisso.Assunto, compromisso.Local, compromisso.HoraInicio, compromisso.DataCompromisso.ToShortDateString());
            }
            Console.ReadLine();
        }

        public void VisualizarCompromissosEntreDatas()
        {
            Console.Clear();
            Console.Write("Digite a Data Inicial (Data Padrão BR):");
            DateTime dataCompromisso = Convert.ToDateTime(Console.ReadLine());
            Console.Clear();
            Console.Write("Digite a Data Final (Data Padrão BR):");
            DateTime dataTermino = Convert.ToDateTime(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"Consulta em andamento : {dataCompromisso.ToString("d")} e {dataTermino.ToString("d")}");

            ConfigurarTela("Visualizando os compromissos...");

            List<Compromisso> compromissos =
                controlador.ObterCompromissosEntre(dataCompromisso, dataTermino, controlador.SelecionarTodosOsCompromissos());

            if (compromissos.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Não existem registros cadastrados!");
                Console.ReadLine();
            }
        }
    }
}
