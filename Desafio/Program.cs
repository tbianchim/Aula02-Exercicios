using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    class Program
    {
        public static Hashtable hashPF = new Hashtable();
        public static Hashtable hashPJ = new Hashtable();
        public static List<ClientePessoaFisica> listPF = new List<ClientePessoaFisica>();
        public static List<ClientePessoaJuridica> listPJ = new List<ClientePessoaJuridica>();

        public static List<ContaCorrente> listCC = new List<ContaCorrente>();
        public static Hashtable hashCC = new Hashtable();

        public static List<ContaPoupanca> listCP = new List<ContaPoupanca>();
        public static Hashtable hashCP = new Hashtable();

        public static List<ContaSalario> listCS = new List<ContaSalario>();
        public static Hashtable hashCS = new Hashtable();

        static void Main(string[] args)
        {
            // - Um banco possui três diferentes tipos de contas: corrente, poupança e salário.
            // - Clientes podem ser pessoas físicas ou jurídicas. 
            // - Todas as contas tem cliente, saldo e lançamentos. 
            // - Elas podem receber depósitos, saques e pagamentos. 
            // - A conta salário só pode ter cliente pessoa física e 
            // - a conta poupança possui o rendimento de 0,5 % de juros ao mês com a data base do começo do mês.

            // DADOS INICIAIS

            listPF.Add(new ClientePessoaFisica() { Nome = "TARCISIO" });
            hashPF.Add("TARCISIO", 0);
            listPF.Add(new ClientePessoaFisica() { Nome = "PRISCILA" });
            hashPF.Add("PRISCILA", 1);

            listPJ.Add(new ClientePessoaJuridica() { Nome = "FELIPE" });
            hashPJ.Add("FELIPE", 0);
            listPJ.Add(new ClientePessoaJuridica() { Nome = "CECILIA" });
            hashPJ.Add("CECILIA", 0);

            listCC.Add(new ContaCorrente() { numero = 1, cliente = listPF.ElementAt(0) });
            hashCC.Add(1, 0);
            listCS.Add(new ContaSalario(2, listPF.ElementAt(1), 1500.00, 0.0));
            hashCS.Add(2, 0);
            listCP.Add(new ContaPoupanca() { numero = 3, cliente = listPJ.ElementAt(0) });
            hashCC.Add(3, 0);
            char opcao=' ';
            do
            {
                opcao = Menu();
                switch (opcao)
                {
                    case '1':
                        NovoClientePF();
                        break;
                    case '2':
                        NovoClientePJ();
                        break;
                    case '3':
                        NovaConta(Conta.xTipo.Corrente);
                        break;
                    case '4':
                        NovaConta(Conta.xTipo.Poupanca);
                        break;
                    case '5':
                        NovaConta(Conta.xTipo.Salario);
                        break;
                    case '6':
                        Lancamento("DEPOSITO");
                        break;
                    case '7':
                        Lancamento("SAQUE");
                        break;
                    case '8':
                        Lancamento("PAGAMENTO");
                        break;
                    case '9':
                        Lancamento("RENDIMENTO");
                        break;
                    case '0':
                        Mensagem("Saindo...");
                        Console.Clear();
                        break;
                    default:
                        Mensagem("Opção Inválida, Verifique!");
                        break;
                }
            } while (opcao != '0');


        }

        private static void Lancamento(string funcao)
        {
            FundoTela();
            Console.SetCursorPosition(35, 2);
            Console.WriteLine(funcao);
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("               ║ Conta C/P/S :");
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("               ║      Número :");
            Console.SetCursorPosition(0, 9);
            Console.WriteLine("               ║      Valor :");

            char tipoconta = ' ';
            Console.SetCursorPosition(31, 5);
            tipoconta = Console.ReadKey().KeyChar;

            int numero;
            Console.SetCursorPosition(31, 7);            
            Int32.TryParse(Console.ReadLine(), out numero);

            double valor = 0.0;
            if (!(funcao == "PAGAMENTO" || funcao == "RENDIMENTO"))
            {
                Console.SetCursorPosition(31, 9);
                valor = double.Parse(Console.ReadLine());
            }

            int? index;
            Conta conta = null;
            ContaSalario contaSalario = null;
            ContaPoupanca contaPoup = null;

            if (tipoconta == 'C')
            {
                index = (int?)hashCC[numero];
                if (index != null)
                {
                    conta = listCC.ElementAt((int)index);
                }
            }
            else if (tipoconta == 'P')
            {
                index = (int?)hashCP[numero];
                if (index != null)
                {
                    conta = listCP.ElementAt((int)index);
                    contaPoup = listCP.ElementAt((int)index);
                }
            }
            else if (tipoconta == 'S')
            {
                index = (int?)hashCS[numero];
                if (index != null)
                {
                    conta = listCS.ElementAt((int)index);
                    contaSalario = listCS.ElementAt((int)index);
                }
            }
            else
            {
                Mensagem("Tipo de Conta Inválido, Verifique!");
            }

            if (conta != null)
            {
                if (funcao == "DEPOSITO")
                {
                    conta.Deposito(valor);
                }else if (funcao == "SAQUE")
                {
                    conta.Saque(valor);
                }else if (funcao == "PAGAMENTO")
                {                    
                    contaSalario.Pagamento();
                }else if (funcao == "RENDIMENTO")
                {
                    contaPoup.Rendimento();
                }
                
                Mensagem(String.Concat("Operacao ", funcao, " Efetuado Com Sucesso"));
                Mensagem(String.Concat("Cliente: ",conta.cliente.Nome," Saldo Atual: ", conta.saldo));
            }

        }

        private static void NovaConta(Conta.xTipo tipo)
        {
            FundoTela();            
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("               ║            Cadastrar Conta {0}", tipo.ToString());
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("               ║     Número :                                   ║");
            if(!Enum.Equals(tipo,Conta.xTipo.Salario))
            {
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("               ║ Pessoa Fisica(F)/Juridica(J) :                 ║");
            }            
            Console.SetCursorPosition(0, 9);
            Console.WriteLine("               ║    Cliente :                                   ║");
            if (Enum.Equals(tipo, Conta.xTipo.Salario))
            {
                Console.SetCursorPosition(0, 11);
            Console.WriteLine("               ║    Salario :");
            }
            Console.SetCursorPosition(30, 5);
            int numero;
            Int32.TryParse(Console.ReadLine(), out numero);
            char FouJ = ' ';
            if (!Enum.Equals(tipo, Conta.xTipo.Salario))
            {
                Console.SetCursorPosition(48, 7);
                FouJ = Console.ReadKey().KeyChar;
            }
            else
            {
                FouJ = (char)'F';
            }
            Console.SetCursorPosition(30, 9);
            string nome = Console.ReadLine();

            double salario=0.0;
            if (Enum.Equals(tipo, Conta.xTipo.Salario))
            {
                Console.SetCursorPosition(30, 11);
                salario = double.Parse(Console.ReadLine());
            }

            Cliente cli = null;
            int? index;
            if (FouJ == 'F')
            {
                index = (int?)hashPF[nome];
                if (index != null) { cli = listPF.ElementAt((int)index); }

            }else if (FouJ == 'J')
            {
                index = (int?)hashPJ[nome];
                if (index != null) { cli = listPJ.ElementAt((int)index); }
            }            

            if (cli != null)
            {
                char x = Mensagem("Digite S Para Confirma os Dados?");
                if (x == 'S' || x == 's')
                {
                    if (Enum.Equals(tipo, Conta.xTipo.Corrente))
                    {
                        listCC.Add(new ContaCorrente() { numero = numero, cliente = cli });
                        hashCC.Add(numero, listCC.Count - 1);
                    }
                    else if (Enum.Equals(tipo, Conta.xTipo.Poupanca))
                    {
                        listCP.Add(new ContaPoupanca() { numero = numero, cliente = cli });
                        hashCP.Add(numero, listCP.Count - 1);
                    }
                    else
                    {
                        listCS.Add(new ContaSalario(numero, (ClientePessoaFisica) cli, 0.0 ,salario));
                        hashCS.Add(numero, listCS.Count - 1);
                    }

                        Mensagem("Conta Inserido com Sucesso.");
                }
            }
            else  
            {
                Mensagem("Cliente não encontrado, Verifique!");
            }

        }

        private static char Mensagem(string v)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(16, 7);            
            Console.WriteLine("┌──────────────────────────────────────────────┐");
            Console.SetCursorPosition(16, 8);
            Console.WriteLine("│                                              │");
            Console.SetCursorPosition(16, 9);
            Console.WriteLine("└──────────────────────────────────────────────┘");
            Console.SetCursorPosition(17, 8);
            Console.WriteLine(v);
            Console.SetCursorPosition(62, 8);
            Console.ResetColor();
            return Console.ReadKey(true).KeyChar;
        }

        private static char Menu()
        {
            FundoTela();
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("               ║       1 - Novo Cliente Pessoa Física           ║");
            Console.WriteLine("               ║       2 - Novo Cliente Pessoa Juridica         ║");
            Console.WriteLine("               ║       3 - Cadastrar Conta Corrente             ║");
            Console.WriteLine("               ║       4 - Cadastrar Conta Poupança             ║");
            Console.WriteLine("               ║       5 - Cadastrar Conta Salario              ║");
            Console.WriteLine("               ║       6 - Efetuar Depósito                     ║");
            Console.WriteLine("               ║       7 - Efetuar Saque                        ║");
            Console.WriteLine("               ║       8 - Efetuar Pagamento                    ║");
            Console.WriteLine("               ║       9 - Aplicar Rendimento                   ║");
            Console.WriteLine("               ║       0 - Sair                                 ║");
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("               ║                Informe opção: [   ]            ║");
            Console.SetCursorPosition(49, 15);
            char opcao = Console.ReadKey().KeyChar;
            return opcao;
        }

        private static void NovoClientePF()
        {
            FundoTela();
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("               ║           Novo Cliente Pessoa Física           ║");
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("               ║       Nome :                                   ║");
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("               ║       CPF  :                                   ║");            
            Console.SetCursorPosition(30, 5);
            string nome = Console.ReadLine();
            Console.SetCursorPosition(30, 7);
            string cpf = Console.ReadLine();
            char x = Mensagem("Digite S Para Confirma os Dados?");
            if (x=='S' || x=='s')
            {
                listPF.Add(new ClientePessoaFisica() { Nome = nome, CPF = cpf });
                hashPF.Add(nome.ToUpper(), listPF.Count - 1);
                Mensagem("Cliente Inserido com Sucesso.");
            }           
            

        }

        private static void NovoClientePJ()
        {
            FundoTela();
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("               ║           Novo Cliente Pessoa Jurídica         ║");
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("               ║       Nome :                                   ║");
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("               ║       CNPJ :                                   ║");
            Console.SetCursorPosition(30, 5);
            string nome = Console.ReadLine();
            Console.SetCursorPosition(30, 7);
            string cnpj = Console.ReadLine();
            char x = Mensagem("Digite S Para Confirma os Dados?");
            if (x == 'S' || x == 's')
            {
                listPJ.Add(new ClientePessoaJuridica() { Nome = nome, CNPJ = cnpj });
                hashPJ.Add(nome.ToUpper(), listPJ.Count - 1);
                Mensagem("Cliente Inserido com Sucesso.");
            }
      
        }

        private static void FundoTela()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("               ╔════════════════════════════════════════════════╗");
            Console.WriteLine("               ║                                                ║");
            Console.WriteLine("               ║                                                ║");
            Console.WriteLine("               ║                                                ║");
            Console.WriteLine("               ║                                                ║");
            Console.WriteLine("               ║                                                ║");
            Console.WriteLine("               ║                                                ║");
            Console.WriteLine("               ║                                                ║");
            Console.WriteLine("               ║                                                ║");
            Console.WriteLine("               ║                                                ║");
            Console.WriteLine("               ║                                                ║");
            Console.WriteLine("               ║                                                ║");
            Console.WriteLine("               ║                                                ║");
            Console.WriteLine("               ║                                                ║");
            Console.WriteLine("               ║                                                ║");
            Console.WriteLine("               ║                                                ║");
            Console.WriteLine("               ╚════════════════════════════════════════════════╝");            
        }
    }
}
