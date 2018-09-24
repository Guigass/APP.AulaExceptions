using System;
using static System.Console;

namespace APP.Excecao02
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Informe um número:");
            int num1 = int.Parse(ReadLine());

            WriteLine("Informe outro número:");
            int num2 = int.Parse(ReadLine());

            WriteLine("Qual operação?");
            string operador = ReadLine().ToUpperInvariant();

            var calculadora = new Calculadora();

            try
            {
                int resultado = calculadora.Executar(num1, num2, operador);
                GetResultado(resultado);
            }
            catch (CalcularOperacaoNaoSuportadaException error)
            {
                WriteLine(error);
            }
            catch (CalcularException error)
            {
                WriteLine(error);
            }
            catch (Exception error)
            {
                WriteLine($"Ocorreu um erro inesperado. {error}");
            }
            finally
            {
                WriteLine("Bloco finally");
            }

            WriteLine("\nEnter para fechar o programa.");
            ReadLine();
        }

        private static void GetResultado(int paramResultado)
        {
            WriteLine($"Resultado: {paramResultado}");
        }

        #region Global Unhandle Exception
        private static void GetExcecaoNaoTratada(object sender, UnhandledExceptionEventArgs e)
        {
            WriteLine("Desculpe, ocorreu um erro inesperado. Aplicação será fechada!");
        }
        #endregion
    }

    public class Calculadora
    {
        public int Executar(int param1, int param2, string operador)
        {
            string nonNulo = operador ?? throw new ArgumentNullException(nameof(operador));

            if (operador == "/")
            {
                try
                {
                    return Dividir(param1, param2);
                }
                catch (ArithmeticException error)
                {
                    throw new CalcularException("Ocorreu um erro durante a divisão", error);
                }
            }
            else
            {
                throw new CalcularOperacaoNaoSuportadaException(operador);
            }
        }

        private int Dividir(int paramNumero, int paramDivisor)
        {
            return paramNumero / paramDivisor;
        }
    }
}
