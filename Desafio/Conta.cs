using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    abstract class Conta
    {
        public Cliente cliente { get; set; }
        public double saldo { get; set; }
        public enum xTipo { Poupanca, Corrente, Salario }
        public xTipo tipo { get; set; }
        public int numero { get; set; }

        public void Deposito(double valor)
        {
            this.saldo = this.saldo + valor;
         
        }


        public void Saque(double valor)
        {
            this.saldo = this.saldo - valor;
        
        }
        
    }
}
