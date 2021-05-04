using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hyrule_bank
{
    public class Conta
    {
        private Cliente Cliente { get; set; }
        private Agencia Agencia { get; set; }
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set;}
        private double Credito { get; set; }

        public Conta(Cliente cliente, Agencia agencia, TipoConta tipoConta, double credito)
        {
            Cliente = cliente;

            if (Enum.IsDefined(typeof(Agencia), agencia) == false)
            {
                throw new ArgumentOutOfRangeException("agencia", String.Format("{0} é uma opção inválida!", agencia));
            }
            
            Agencia = agencia;

            if (Enum.IsDefined(typeof(TipoConta), tipoConta) == false)
            {
                throw new ArgumentOutOfRangeException("tipoConta", String.Format("{0} é uma opção inválida!", tipoConta));
            }

            TipoConta = tipoConta;

            Saldo = 0;
            Credito = credito;
        }

        public void Sacar(double valor)
        {
            if (Saldo - valor < (Credito * -1 ))
            {
                throw new SaldoInsuficienteException("Operação não realizado.\nLimite de Crédito atingido!");
            }

            Saldo -= valor;

            Console.WriteLine($"Saldo atual da conta de {Cliente} é {Saldo}");

        }
        public void Depositar(double valor)
        {
            Saldo += valor;

            Console.WriteLine($"Saldo atual da conta de {Cliente} é {Saldo}");
        }

        public void Transferir(double valor, Conta conta)
        {
            Sacar(valor);
            conta.Depositar(valor);
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Cliente " + Cliente + " | ";
            retorno += "Agencia: " + Agencia + " | ";
            retorno += "TipoConta: " + TipoConta + " | ";
            retorno += "Saldo: " + Saldo + " | ";
            retorno += "Crédito: " + Credito;
            return retorno;
        }

    }
}
