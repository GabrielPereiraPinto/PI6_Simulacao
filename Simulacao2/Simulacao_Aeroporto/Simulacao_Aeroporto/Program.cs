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


            Console.WriteLine("===========================================+++++++++=============");
            Console.WriteLine("============================BEM VINDO============================");
            Console.WriteLine("=================================================================");
            Console.WriteLine("Para Simular seu tempo gasto em um aeroporto, por favor digite:");
            Console.WriteLine("O Peso da sua bagagem:");
            usuario.Bagagem = float.Parse(Console.ReadLine());
            Console.WriteLine("O Peso da sua bagagem de mão:");
            usuario.BagagemMao = float.Parse(Console.ReadLine());


           


        }

        static List<BagagemPessoa> geraFila()
        {
            var filaRandom = new Random().Next(0, 20);
            var fila = new List<BagagemPessoa>();
            for (int i = 0; i < filaRandom; i++)
            {
                var bagagem = new Random().Next(0, 30);
                var bagagemMao = new Random().Next(0, 15);

                var usuarioFila = new BagagemPessoa(bagagem, bagagemMao);

                fila.Add(usuarioFila);
            }

            return fila;
        }
    }
}
