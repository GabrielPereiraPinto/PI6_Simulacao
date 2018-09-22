using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacao_Aeroporto
{
    class Program
    {
        static void Main(string[] args)
        {

            var usuario = new BagagemPessoa();

            Console.WriteLine("=================================================================");
            Console.WriteLine("============================BEM VINDO============================");
            Console.WriteLine("=================================================================");
            Console.WriteLine("Para Simular seu tempo gasto em um aeroporto, por favor digite:");

            Console.WriteLine("O Peso da sua bagagem:");
            usuario.Bagagem = Int32.Parse(Console.ReadLine());

            Console.WriteLine("O Peso da sua bagagem de mão:");
            usuario.BagagemMao = Int32.Parse(Console.ReadLine());

            if (usuario.Bagagem != 0 || usuario.BagagemMao > 10)
            {

                Console.WriteLine("Você acaba de entrar na fila para pesar suas malas e fazer check-in");

                var filaBagagem = geraFila(14); //média de 7 pessoas
                Console.WriteLine($"Atualmente existem {filaBagagem.Count()} pessoas na sua frente na fila");

                int tempoFila = 0;
                foreach (var pessoa in filaBagagem)
                {
                    pessoa.PesagemBagagem();
                    pessoa.PesagemBagagemMao();
                    tempoFila += pessoa.TempoUsuario;
                }
                Console.WriteLine($"Foram necessários {tempoFila} minutos para que todas pessoas a sua frente fossem atendidas");

                usuario.TempoUsuario += tempoFila;
                int tempoPesagem = 0;
                tempoPesagem += usuario.PesagemBagagem();
                tempoPesagem += usuario.PesagemBagagemMao();

                if (usuario.BagagemExtra)
                    Console.WriteLine("Sua Bagagem estava acima do peso de 23 kgs, foi necessário pagar pelo peso extra");

                if (usuario.DespacharBagagemMao)
                    Console.WriteLine("Sua bagagem de mão estava acima do limite de 10 kgs e precisou ser despachada");

                Console.WriteLine($"Foram necessários {tempoPesagem} minutos para terminar de pesar a suas bagagens e fazer seu check-in");
            }
            else
            {
                var filaRapida = new Random().Next(0, 8); //média de 4 pessoas
                Console.WriteLine("Você não tem bagagens para despachar, é possível fazer apenas check-in em um guichê rapido");
                Console.WriteLine($"Atualmente existem {filaRapida} pessoas na sua frente na fila, levará {filaRapida * 4} minutos para  o Check-in");
                usuario.TempoUsuario += filaRapida * 4;

            }

            var pessoasInspecao = new Random().Next(0, 8); //média de 4 pessoas
            int tempoInspecao = 0;
            for (int i = 0; i < pessoasInspecao; i++)
            {
                tempoInspecao += new Random().Next(4, 6);
            }

            usuario.TempoUsuario +=  tempoInspecao;
            Console.WriteLine($"Você está se encaminhando para fila de inspeção de bagagens, atualmente existem {pessoasInspecao}  pessoas a sua frente.");
            Console.WriteLine($"Foram necessários {tempoInspecao} minutos para que chegasse sua vez.");

            var inspecaoBagagem = new Random().Next(0, 100);
            if (inspecaoBagagem > 70)
            {
                Console.WriteLine($"Foi Necessário revistar a sua bagagem de mão, isso levou mais 5 minutos");
                usuario.TempoUsuario += 5;
            }

            var portao = new Random().Next(1, 5);
            var tempoPortao = usuario.TempoPortao(portao);

            Console.WriteLine($"O Seu portão de entrada será o portão de número  {portao}, que fica a {tempoPortao} minutos de distancia");

            if(portao == 5)
            {               
                Console.WriteLine($"O Portão de número 5 necessita de Onibus até o avião, isso levará mais 10 minutos");
                usuario.TempoUsuario += 10;
            }

            Console.WriteLine($"Você Embarcou em seu Avião");
            Console.WriteLine($"Foram necessários {usuario.TempoUsuario} minutos para que você termina-se todo o processo.");

            Console.ReadLine();
        }

        static List<BagagemPessoa> geraFila(int tamanhoMax)
        {
            var filaRandom = new Random().Next(0, tamanhoMax);
            var fila = new List<BagagemPessoa>();
            for (int i = 0; i < filaRandom; i++)
            {
                var bagagem = new Random().Next(5, 30);
                var bagagemMao = new Random().Next(0, 15);

                var usuarioFila = new BagagemPessoa(bagagem, bagagemMao);

                fila.Add(usuarioFila);
            }

            return fila;
        }
    }
}
