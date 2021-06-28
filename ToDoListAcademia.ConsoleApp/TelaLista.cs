using System;
using System.Collections.Generic;
using ToDoListAcademia.Controladores;
using ToDoListAcademia.Dominio;

namespace ToDoListAcademia.ConsoleApp
{
    public class TelaLista : Tela<Lista>
    {
        private readonly ControladorLista controlador;

        public TelaLista(ControladorLista ctrl) : base("To Do List Academia")
        {
            controlador = ctrl;
        }

        public void CadastrarNovaTarefa()
        {
            ConfigurarTela("Cadastrando uma nova tarefa...");

            Console.Write("Digite o título da tarefa: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a data de abertura da tarefa: ");
            DateTime dataAbertura = Convert.ToDateTime(Console.ReadLine());

            Prioridade prioridade;
            string strPrioridade;

            do
            {
                Console.WriteLine("Qual a prioridade da tarefa? (Alta, Media ou Baixa)");
                strPrioridade = Console.ReadLine();

            } while (strPrioridade != "Alta" && strPrioridade != "Media" && strPrioridade != "Baixa");

            prioridade = ConfiguracoesPrioridade.DefinirPrioridade(strPrioridade);

            controlador.InserirNovaLista(new Lista(titulo, dataAbertura, (int)prioridade));

            ApresentarMensagem("Tarefa cadastrada com sucesso!", Mensagem.Sucesso);
        }

        public void AtualizarTarefa()
        {
            ConfigurarTela("Atualizando uma tarefa...");

            VisualizarTarefasEmAberto();

            Console.Write("\nDigite o ID da tarefa que deseja atualizar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Lista lista = controlador.SelecionarTarefaPorId(id);

            Console.Write("Digite o título da tarefa: ");
            lista.Titulo = Console.ReadLine();

            Prioridade prioridade;
            string strPrioridade;

            do
            {
                Console.WriteLine("Qual a prioridade da tarefa? (Alta, Media ou Baixa)");
                strPrioridade = Console.ReadLine();

            } while (strPrioridade != "Alta" && strPrioridade != "Media" && strPrioridade != "Baixa");

            prioridade = ConfiguracoesPrioridade.DefinirPrioridade(strPrioridade);

            lista.Prioridade = (int)prioridade;

            controlador.AtualizarTarefa(lista);

            ApresentarMensagem("Tarefa atualizada com sucesso!", Mensagem.Sucesso);
        }

        public void ExcluirTarefa()
        {
            ConfigurarTela("Excluindo uma tarefa...");

            VisualizarTodasAsTarefas();

            Console.Write("\nDigite o ID da tarefa que deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Lista l = controlador.SelecionarTarefaPorId(id);

            controlador.ExcluirTarefa(l);

            ApresentarMensagem("Tarefa excluída sucesso!", Mensagem.Sucesso);
        }

        public void VisualizarTodasAsTarefas()
        {
            ConfigurarTela("Visualizando todas as tarefas...");

            List<Lista> listas = controlador.SelecionarTodasAsTarefas();

            if (ListaVazia(listas))
            {
                ApresentarMensagem("Nenhuma tarefa cadastrada!", Mensagem.Atencao);
                return;
            }

            string configuracaColunasTabela = "{0,-5} | {1,-25} | {2,-22} | {3,-3} | {4, -10}";

            MontarCabecalhoTabela(configuracaColunasTabela, "Id", "Título", "Data de Criação", "Prioridade");

            foreach (Lista lista in listas)
            {
                Console.WriteLine(configuracaColunasTabela, lista.Id, lista.Titulo, lista.DataCriacao.ToShortDateString(), lista.Prioridade);
            }
            Console.ReadLine();
        }

        public void VisualizarTarefasEmAberto()
        {
            ConfigurarTela("Visualizando tarefas em aberto...");

            List<Lista> tarefasEmAberto = controlador.SelecionarTodasAsTarefasEmAberto();

            if (ListaVazia(tarefasEmAberto))
            {
                ApresentarMensagem("Nenhuma tarefa em aberto!", Mensagem.Atencao);
                return;
            }

            string configuracaColunasTabela = "{0,-5} | {1,-25} | {2,-22} | {3,-3} | {4, -10}";

            MontarCabecalhoTabela(configuracaColunasTabela, "Id", "Título", "Data de Criação", "%", "Prioridade");

            foreach (Lista lista in tarefasEmAberto)
            {
                Console.WriteLine(configuracaColunasTabela, lista.Id, lista.Titulo, lista.DataCriacao.ToShortDateString(), lista.Prioridade);
            }
            Console.ReadLine();
        }

        public void VisualizarTarefasConcluidas()
        {
            ConfigurarTela("Visualizando tarefas concluídas...");

            List<Lista> listaConcluida = controlador.SelecionarTodasAsTarefasConcluidas();

            if (ListaVazia(listaConcluida))
            {
                ApresentarMensagem("Nenhuma tarefa concluída!", Mensagem.Atencao);
                return;
            }

            string configuracaColunasTabela = "{0,-5} | {1,-25} | {2,-22} | {3,-22} | {4,-4}";

            MontarCabecalhoTabela(configuracaColunasTabela, "Id", "Título", "Data de Criação", "Data de Conclusão", "Prioridade");

            foreach (Lista lista in listaConcluida)
            {
                Console.WriteLine(configuracaColunasTabela, lista.Id, lista.Titulo, lista.DataCriacao.ToShortDateString(),
                    lista.DataConclusao.ToShortDateString(), lista.Prioridade);
            }

            Console.ReadLine();
        }
    }
}
