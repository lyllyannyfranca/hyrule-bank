using System;
using System.Collections.Generic;

namespace hyrule_bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static List<Cliente> listCliente = new List<Cliente>();
        
        static void Main(string[] args)
        {
            DesenharLogo();

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                try 
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            ListarClientes();
                            break;
                        case "2":
                            CadastrarCliente();
                            break;
                        case "3":
                            ListarContas();
                            break;
                        case "4":
                            InserirConta();
                            break;
                        case "5":
                            Transferir();
                            break;
                        case "6":
                            Sacar();
                            break;
                        case "7":
                            Depositar();
                            break;
                        case "C":
                            Console.Clear();
                            break;

                        default:
                            throw new ArgumentOutOfRangeException(opcaoUsuario,"Opção inválida!");
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message + "\n");
                }
                

                opcaoUsuario = ObterOpcaoUsuario();

            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.WriteLine("Que a Deusa Hylia sorria para você.");
            Console.ReadLine();

        }

        private static void DesenharLogo()
        {
            Console.WriteLine("\t" + "       ___");
            Console.WriteLine("\t" + "      /" + "   \\");
            Console.WriteLine("\t" + "     |" + "  |  |");
            Console.WriteLine("\t" + "     |" + "  |  |");
            Console.WriteLine("\t" + "      \\" + "___/" + "\n");

            Console.WriteLine("Hyrule Bank - Suas ruppies prosperando com a benção da Deusa Hylia! \n");
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Listar clientes");
            Console.WriteLine("2 - Cadastrar Cliente");
            Console.WriteLine("3 - Listar contas");
            Console.WriteLine("4 - Inserir nova conta");
            Console.WriteLine("5 - Transferir");
            Console.WriteLine("6 - Sacar");
            Console.WriteLine("7 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();

            Console.WriteLine();

            return opcaoUsuario;
        }

        private static void CadastrarCliente()
        {
            Console.WriteLine("Cadastrar Cliente\n");

            Console.Write("Digite o nome do Cliente: ");
            string nomeCliente = Console.ReadLine();

            Console.Write("\n");

            Console.WriteLine("Digite o número correspondente a Etnia do Cliente");
            Console.WriteLine("1 - Zora");
            Console.WriteLine("2 - Goron");
            Console.WriteLine("3 - Gerudo");
            Console.WriteLine("4 - Hylian");
            Console.WriteLine("5 - Rito");
            Console.WriteLine("6 - Sheikah");
            int opcao = int.Parse(Console.ReadLine());

            Console.Write("\n");

            try
            {
                Cliente cliente = new Cliente(nomeCliente, etniaCliente: (EtniaCliente)opcao);
                
                listCliente.Add(cliente);
                
                Console.WriteLine("Cadastro realizado com sucesso!\n");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message + "\n");
            }
        }

        private static void ListarClientes()
        {
            Console.WriteLine("Listar clientes");

            if (listCliente.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.\n");
                return;
            }

            for (int i = 0; i < listCliente.Count; i++)
            {
                Cliente cliente = listCliente[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(cliente);
            }

            Console.WriteLine();
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.\n");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }

            Console.WriteLine();
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta\n");

            Console.Write("");

            Console.Write("Digite o número do cliente: ");
            int indiceCliente = int.Parse(Console.ReadLine());

            Console.Write("\n");

            Console.WriteLine("Digite o número correspondente a agência do Cliente ");
            Console.WriteLine("1 - CentralHyrule");
            Console.WriteLine("2 - DominioZora");
            Console.WriteLine("3 - VilaRito");
            Console.WriteLine("4 - CidadeGoron");
            Console.WriteLine("5 - CidadeGerudo");
            Console.WriteLine("6 - VilaKakariko");
            Console.WriteLine("7 - VilaHateno");

            int entradaAgencia = int.Parse(Console.ReadLine());

            Console.Write("\n");

            Console.WriteLine("Digite o número correspondente ao tipo de Conta ");
            Console.WriteLine("1 - Conta Corrente");
            Console.WriteLine("2 - Conta Poupança");
            Console.WriteLine("3 - Conta Salário");

            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("\n");

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Console.Write("\n");

            try
            {
                Conta novaConta = new Conta(cliente: listCliente[indiceCliente],
                                            agencia: (Agencia)entradaAgencia,
                                            tipoConta: (TipoConta)entradaTipoConta,
                                            credito: entradaCredito);

                listContas.Add(novaConta);

                Console.WriteLine("Conta aberta com sucesso!\n");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorDeSaque = double.Parse(Console.ReadLine());

            try
            {
                listContas[indiceConta].Sacar(valorDeSaque);
            }
            catch(SaldoInsuficienteException e)
            {
                Console.WriteLine(e.Message);
            }

            if (SaldoInsuficienteException.ContadorTentativas > 10)
            {
                Console.WriteLine("Entre em contato com seu gerente para uma avaliação de aumento do valor do Crédito Especial.");
            }
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            try
            {
                listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
            }
            catch(SaldoInsuficienteException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
