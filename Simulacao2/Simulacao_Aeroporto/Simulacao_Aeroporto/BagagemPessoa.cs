using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacao_Aeroporto
{
    public class BagagemPessoa
    {
        public int Bagagem { get; set; }
        public int BagagemMao { get; set; }
        public int TempoUsuario { get; set; }
        public bool DespacharBagagemMao { get; set; }
        public bool BagagemExtra { get; set; }

        public BagagemPessoa(int bagagem, int bagagemMao)
        {
            this.Bagagem = bagagem;
            this.BagagemMao = bagagemMao;
            this.TempoUsuario = 0;
            this.DespacharBagagemMao = false;
            this.BagagemExtra = false;
        }

        public BagagemPessoa()
        {
            this.TempoUsuario = 0;
            this.DespacharBagagemMao = false;
            this.BagagemExtra = false;
        }

        public int PesagemBagagem()
        {
            if (Bagagem == 0)
                return 0;

            int tempoTotalPesagem = 0;
            var pesagemBagagem = new Random().Next(5, 10);
            var acertoPesoExtra = new Random().Next(5, 10);

            tempoTotalPesagem += pesagemBagagem;

            if (Bagagem > 23)
            {
                BagagemExtra = true;
                tempoTotalPesagem += acertoPesoExtra;
            }

            TempoUsuario += tempoTotalPesagem;
            return tempoTotalPesagem;
        }

        public int PesagemBagagemMao()
        {
            if (BagagemMao == 0)
                return 0;

            int tempoTotalPesagemMao = 0;

            var random = new Random().Next(0, 100);
            var pesagemBagagemMao = new Random().Next(5, 10);
            var acertoPesoExtra = new Random().Next(5, 10);

            if (random < 70)
            {
                tempoTotalPesagemMao += pesagemBagagemMao;

                if (BagagemMao > 10)
                {
                    DespacharBagagemMao = true;
                    tempoTotalPesagemMao += acertoPesoExtra;
                }
            }

            TempoUsuario += tempoTotalPesagemMao;
            return tempoTotalPesagemMao;
        }

        public int TempoPortao(int portao)
        {
            int tempoPortao = 0;
            switch (portao)
            {
                case 1:
                case 2:
                    tempoPortao += 10;
                    break;

                case 3:
                case 4:
                case 5:
                    tempoPortao += 15;
                    break;
            }

            TempoUsuario += tempoPortao;
            return tempoPortao;
        }

    }
}
