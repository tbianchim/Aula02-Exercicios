using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    class ContaSalario : Conta        
    {
        public double Salario { get; set; }
        public ContaSalario(int num, ClientePessoaFisica cli, double salario, double saldo)
        {
            this.numero = num;
            this.cliente = cli;
            this.Salario = salario;
            this.saldo = saldo;
            this.tipo = xTipo.Salario;
        }

        public void Pagamento()
        {
            this.saldo = this.saldo + this.Salario;
        }


    }
}
