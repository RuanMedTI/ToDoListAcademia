using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ToDoListAcademia.Controladores;
using ToDoListAcademia.Dominio;

namespace ToDoListAcademia.ConsoleApp
{
    public class TelaContatos : Tela<Contato>
    {
        private readonly ControladorContatos controlador;

        public TelaContatos(ControladorContatos ctrl) : base("Gerenciador de Contatos Academia")
        {
            controlador = ctrl;
        }

        public void CadastrarNovoContato()
        {
            ConfigurarTela("Cadastrando uma novo contato...");

            Console.Write("Digite o nome do Contato: ");
            string nome = Console.ReadLine();

            string email;
            do
            {
                Console.Write("Digite o email do contato: ");
                email = Console.ReadLine();

                if (!EnderecoDeEmailValido(email))
                    ApresentarMensagem("Por favor escreva um endereço de email válido!", Mensagem.Atencao);

            } while (!EnderecoDeEmailValido(email));

            string telefone;
            do
            {
                Console.Write("Digite o número de telefone (DDD + 9 Numeros): ");
                telefone = Console.ReadLine();

                if (!NumeroTelefoneValido(telefone))
                    ApresentarMensagem("Por favor escreva um número de válido!", Mensagem.Atencao);

            } while (!NumeroTelefoneValido(telefone));

            Console.Write("Digite a Empresa do Contato: ");
            string empresa = Console.ReadLine();

            Console.Write("Digite o Cargo do Contato: ");
            string cargo = Console.ReadLine();

            controlador.InserirNovoContato(new Contato(nome, email, telefone, empresa, cargo));

            ApresentarMensagem("Contato cadastrado com sucesso!", Mensagem.Sucesso);
        }

        public void AtualizarContato()
        {
            ConfigurarTela("Atualizando um contato...");

            VisualizarTodosOsContatos();

            Console.Write("\nDigite o ID da tarefa que deseja atualizar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Contato contato = controlador.SelecionarContatoPorId(id);

            Console.Write("Digite o nome do Contato: ");
            contato.Nome = Console.ReadLine();

            string email;
            do
            {
                Console.Write("Digite o email do contato: ");
                email = Console.ReadLine();

                if (!EnderecoDeEmailValido(email))
                    ApresentarMensagem("Por favor escreva um endereço de email válido!", Mensagem.Atencao);

            } while (!EnderecoDeEmailValido(email));

            string telefone;
            do
            {
                Console.Write("Digite o número de telefone (DDD + 9 Numeros): ");
                telefone = Console.ReadLine();

                if (!NumeroTelefoneValido(telefone))
                    ApresentarMensagem("Por favor escreva um número de válido!", Mensagem.Atencao);

            } while (!NumeroTelefoneValido(telefone));

            Console.Write("Digite a Empresa do Contato: ");
            contato.Empresa = Console.ReadLine();

            Console.Write("Digite o Cargo do Contato: ");
            contato.Cargo = Console.ReadLine();

            controlador.AtualizarContato(contato);

            ApresentarMensagem("Contato atualizado com sucesso!", Mensagem.Sucesso);
        }

        public void ExcluirContato()
        {
            ConfigurarTela("Excluindo um contato...");

            VisualizarTodosOsContatos();

            Console.Write("\nDigite o ID do contato que deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Contato c = controlador.SelecionarContatoPorId(id);

            controlador.ExcluirContato(c);

            ApresentarMensagem("Contato excluído sucesso!", Mensagem.Sucesso);
        }

        public void VisualizarTodosOsContatos()
        {
            ConfigurarTela("Visualizando todos os contatos...");

            List<Contato> contatosConcluidos = controlador.SelecionarTodosOsContatos();

            if (ListaVazia(contatosConcluidos))
            {
                ApresentarMensagem("Nenhum contato cadastrado!", Mensagem.Atencao);
                return;
            }

            string configuracaColunasTabela = "{0,-5} | {1,-25} | {2,-22} | {3,-3} | {4, -10} | {5, -14}";

            MontarCabecalhoTabela(configuracaColunasTabela, "Id", "Nome", "E-mail", "Telefone", "Empresa", "Cargo");

            foreach (Contato contato in contatosConcluidos)
            {
                Console.WriteLine(configuracaColunasTabela, contato.Id, contato.Nome, contato.Email, contato.Telefone, contato.Empresa, contato.Cargo);
            }
            Console.ReadLine();
        }

        private bool EnderecoDeEmailValido(string email)
        {
            bool Valido = Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);

            return Valido;
        }

        private bool NumeroTelefoneValido(string numero)
        {
            if (numero.Length < 11)
                return false;

            return true;
        }
    }
}
