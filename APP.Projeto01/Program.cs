using System;
using static System.Console;

namespace APP.Projeto01
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Cenário 8 - Exceção não tratada
            /* NOTA - Boa prática. Mensagem mais amigável para exceções não tratadas. */
            //AppDomain processoAppDomain = AppDomain.CurrentDomain;
            //processoAppDomain.UnhandledException += new UnhandledExceptionEventHandler(GetExcecaoNaoTratada);
            #endregion

            WriteLine("Informe primeiro número:");
            int num1 = int.Parse(ReadLine());

            WriteLine("Informe segundo número:");
            int num2 = int.Parse(ReadLine());

            WriteLine("Qual operação?");
            string operador = ReadLine().ToUpperInvariant();

            // Cenários
            Cenarios.Executar_Cenario1(num1, num2, operador);
            //Cenarios.Executar_Cenario2(num1, num2, operador);
            //Cenarios.Executar_Cenario3(num1, num2, operador);
            //Cenarios.Executar_Cenario4(num1, num2, operador);
            //Cenarios.Executar_Cenario5(num1, num2, operador);
            //Cenarios.Executar_Cenario6(num1, num2, operador);
            //Cenarios.Executar_Cenario7(num1, num2, operador);

            WriteLine("\nEnter para fechar o programa.");
            ReadLine();
        }

        #region Cenário 8 - Exceção não tratada
        private static void GetExcecaoNaoTratada(object sender, UnhandledExceptionEventArgs e)
        {
            WriteLine("Desculpe, ocorreu um erro inesperado. Aplicação será fechada!");
        }
        #endregion
    }
}
