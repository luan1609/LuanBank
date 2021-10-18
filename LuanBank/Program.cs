using LuanBank.Classes;
using System;
using System.Collections.Generic;
using LuanBank.Enum;

namespace LuanBank
{
    class Program
    {
        static List<Account> listAccounts = new List<Account>();
        static void Main(string[] args)
        {
            string opcaoUsuario = MenuUser();
            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListAccount();
                        break;
                    case "2":
                        InsertAccount();
                        break;
                    case "3":
                        Transfer();
                        break;
                    case "4":
                        WithDrawal();
                        break;
                    case "5":
                        Deposito();
                        break;
                    case "C":
                        Clear();
                        break;
                    default:
                        throw new ArgumentException();
                }
                opcaoUsuario = MenuUser();
            }

        }

        private static void Clear()
        {
            Console.Clear();
        }

        private static void Transfer()
        {
            Console.Write("Digite o nome do cliente pagador:");
            string pagador = Console.ReadLine();
            Console.Write("Nome do cliente beneficiário: ");
            string beneficiario = Console.ReadLine();
            Console.Write("DIgite o valor que deseja transferir: R$");
            double value = double.Parse(Console.ReadLine());
            for (int i = 0; i < listAccounts.Count; i++)
            {
                Account account = listAccounts[i];
                if (pagador == account.UserName())
                {
                    for (int j = 0; j < listAccounts.Count; j++)
                    {
                        Account account2 = listAccounts[j];
                        if (beneficiario == account2.UserName())
                        {
                            account.Transfer(value, account2);
                        }
                    }

                }
            }
        }
        private static void Deposito()
        {
            Console.Write("Digite o nome do cliente:");
            string nomeDoCliente = Console.ReadLine();
            Console.Write("Quanto deseja depositar: R$");
            double valor = double.Parse(Console.ReadLine());
            for (int i = 0; i < listAccounts.Count; i++)
            {
                Account account = listAccounts[i];
                if (nomeDoCliente == account.UserName())
                {
                    listAccounts[i].Deposit(valor);
                }
            }
        }
        private static void WithDrawal()
        {
            Console.Write("Digite o nome do cliente: ");
            string nomeDoCliente = Console.ReadLine();
            Console.Write("Digite o valor que deseja sacar: R$");
            double valor = double.Parse(Console.ReadLine());
            for (int i = 0; i < listAccounts.Count; i++)
            {
                Account account = listAccounts[i];
                if (nomeDoCliente == account.UserName())
                {
                    listAccounts[i].WithDrawal(valor);
                }
            }
        }

        private static void ListAccount()
        {
            if (listAccounts.Count == 0)
            {
                Console.WriteLine("Lista de contas vazia");
                return;
            }
            for (int i = 0; i < listAccounts.Count; i++)
            {
                Account account = listAccounts[i];
                Console.Write($"#{i + 1} - ");
                Console.WriteLine($"{account}");
            }
        }

        private static void InsertAccount()
        {
            string maisUmCadastro = "S";
            while (maisUmCadastro == "S")
            {
                Console.WriteLine("Digite o tipo de conta que deseja cadastrar");
                Console.Write("1 - Pessoa Jurídica | 2 - Pessoa Física: ");
                int conta = int.Parse(Console.ReadLine());
                while (conta != 1 && conta != 2)
                {
                    Console.WriteLine($"Não existe tipo de conta com número {conta}");
                    Console.WriteLine("Digite o tipo de conta que deseja cadastrar");
                    Console.Write("1 - Pessoa Jurídica | 2 - Pessoa Física: ");
                    conta = int.Parse(Console.ReadLine());
                }
                Console.Write("Digite o nome do cliente: ");
                string name = Console.ReadLine();
                Console.Write("Digite o saldo: ");
                double balance = double.Parse(Console.ReadLine());
                Console.Write("Digite o saldo de crédito: ");
                double credit = double.Parse(Console.ReadLine());
                Account cliente = new Account((AccountType)conta, name, balance, credit);

                listAccounts.Add(cliente);
                Console.WriteLine("Deseja cadastrar mais uma conta?[S/N] ");
                maisUmCadastro = Console.ReadLine().ToUpper();
            }
        }

        private static string MenuUser()
        {
            Console.WriteLine("BEM VINDO AO LUANBANK");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("");
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Cadastrar nova conta");
            Console.WriteLine("3 - Transferência");
            Console.WriteLine("4 - Saque");
            Console.WriteLine("5 - Depósito");
            Console.WriteLine("C - Limpar tela");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
    }
}
