using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hyrule_bank
{
    public class SaldoInsuficienteException : Exception
    {
        public static int ContadorTentativas { get; set; }

        public SaldoInsuficienteException() 
        {
            ContadorTentativas++;
        }

        public SaldoInsuficienteException(string mensagem)
            : base(mensagem) 
        {
            ContadorTentativas++;
        }
        public void VerificarTentativas()
        {
            Console.WriteLine($"Quantidade de vezes que foram tentadas realização de saque com Saldo insuficiente: {ContadorTentativas}");
        }

    }
}
