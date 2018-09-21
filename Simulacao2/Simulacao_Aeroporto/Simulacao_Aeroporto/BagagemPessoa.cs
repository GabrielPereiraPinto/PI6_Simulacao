using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacao_Aeroporto
{
    public class BagagemPessoa
    {
        public float Bagagem { get; set; }
        public float BagagemMao { get; set; }

        public BagagemPessoa(float bagagem, float bagagemMao)
        {
            this.Bagagem = bagagem;
            this.BagagemMao = bagagemMao;
        }

        public BagagemPessoa() { }

    }
}
