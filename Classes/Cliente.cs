using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hyrule_bank
{
    public class Cliente
    {
        private string Nome { get; set; }
        private EtniaCliente EtniaCliente { get; set; }

        public Cliente(string nome, EtniaCliente etniaCliente)
        {
            Nome = nome;
            if (Enum.IsDefined(typeof(EtniaCliente), etniaCliente))
            {
                EtniaCliente = etniaCliente;
            }
            else
            {
                throw new ArgumentOutOfRangeException("etniaCliente", String.Format("{0} é uma opção inválida!", etniaCliente));
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "nome: " + Nome + " | ";
            retorno += "Etnia: " + EtniaCliente;
            return retorno;
        }
    }
}
