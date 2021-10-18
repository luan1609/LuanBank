using LuanBank.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using LuanBank.Classes;

namespace LuanBank.Classes
{
    class Account
    {


        private AccountType AccountType { get; set; }
        private string Name { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }


        public Account(AccountType accountType, string name, double balance, double credit)
        {
            AccountType = accountType;
            Name = name;
            Balance = balance;
            Credit = credit;
        }

        public bool WithDrawal(double withdrawalValue)
        {
            if (Balance - withdrawalValue < Credit * -1)
            {
                Console.WriteLine("Saldo insuficiente.");
                return false;
            }
            else
            {
                Balance -= withdrawalValue;
                Console.WriteLine($" Saque no valor de R${withdrawalValue}, seu saldo atual: R${Balance}");
                return true;
            }
        }

        public bool Deposit(double depositValue)
        {
            Balance += depositValue;
            Console.WriteLine($"Seu saldo atualizado: R${Balance}");
            return true;
        }
        public void Transfer(double valueTransfer, Account destinyAccount)
        {
            if (WithDrawal(valueTransfer))
            {
                destinyAccount.Deposit(valueTransfer);
            }
        }
        public string UserName()
        {
            string name = Name;
            return name;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno = $"Nome do cliente: {Name}|" +
                $"Saldo em conta: {Balance}|" +
                $"Crédito: {Credit}|" +
                $"Tipo de conta: {AccountType}|" +
                $"\n";
            return retorno;
        }
    }

}
