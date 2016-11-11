using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    class ContaPoupanca : Conta
    {
        public ContaPoupanca()
        {
            this.tipo = xTipo.Poupanca;

        }
        public void Rendimento()
        {
            this.saldo = this.saldo + (this.saldo * 0.05);
        }
    }
}
