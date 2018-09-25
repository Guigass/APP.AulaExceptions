using System;
using System.Text;

namespace APP.Projeto05
{
    class Program
    {
        static void Main(string[] args)
        {
            int loopinteiro = 1000000;

            Cenario_1(loopinteiro);

            Cenario_2(loopinteiro);

            Console.ReadLine();
        }

        private static void Cenario_2(int loopinteiro)
        {
            for (int i = 0; i < loopinteiro; i++)
            {
                Console.WriteLine($"Passando por aqui novamente. Tentativa: {i}");
            }
        }

        private static void Cenario_1(int loopinteiro)
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < loopinteiro; i++)
            {
                output.AppendLine($"Passando por aqui novamente. Tentativa: {i}");
            }
            Console.WriteLine(output);
        }
    }
}
