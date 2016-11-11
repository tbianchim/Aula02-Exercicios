using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    class ClientePessoaFisica : Cliente
    {
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
