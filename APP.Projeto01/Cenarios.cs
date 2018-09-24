using System;
using static System.Console;

namespace APP.Projeto01
{
    public class Cenarios
    {
        #region Cenário 1
        public static void Executar_Cenario1(int num1, int num2, string operador)
        {
            var calculadora = new Calculadora();
            int resultado = calculadora.Cenario1(num1, num2, operador);
            GetResultado(resultado);
        }
        #endregion

        #region Cenário 2
        public static void Executar_Cenario2(int num1, int num2, string operador)
        {
            var calculadora = new Calculadora();
            int resultado = calculadora.Cenario2(num1, num2, operador);
            GetResultado(resultado);
        }
        #endregion

        #region Cenário 3
        public static void Executar_Cenario3(int num1, int num2, string operador)
        {
            var calculadora = new Calculadora();
            try
            {
                int resultado = calculadora.Cenario3(num1, num2, null);
                GetResultado(resultado);
            }
            catch (Exception error)
            {
                WriteLine($"Ocorreu um erro inesperado. {error}");
            }
        }
        #endregion

        #region Cenário 4
        public static void Executar_Cenario4(int num1, int num2, string operador)
        {
            var calculadora = new Calculadora();
            try
            {
                int resultado = calculadora.Cenario4(num1, num2, operador);
                GetResultado(resultado);
            }
            catch (ArgumentNullException error)
            {
                WriteLine($"Operação não foi informada. {error}");
            }
            catch (ArgumentOutOfRangeException error)
            {
                WriteLine($"Operação não suportado. {error}");
            }
            catch (Exception error)
            {
                WriteLine($"Ocorreu um erro inesperado. {error}");
            }
            finally
            {
                /* NOTA - Bloco sempre será executado, independente de gerar exceção.
                 * Normalmente utilizado para limpar objetos que não serão mais necessários. */
                WriteLine("Finalizar o bloco");
            }
        }
        #endregion

        #region Cenário 5
        public static void Executar_Cenario5(int num1, int num2, string operador)
        {
            var calculadora = new Calculadora();
            try
            {
                int resultado = calculadora.Cenario5(num1, num2, operador);
                GetResultado(resultado);
            }
            catch (ArgumentNullException error)
            {
                WriteLine($"Operação não foi informada. {error}");
            }
            catch (ArgumentOutOfRangeException error)
            {
                WriteLine($"Operação não suportado. {error}");
            }
            catch (Exception error)
            {
                WriteLine($"Ocorreu um erro inesperado. {error}");
            }
            finally
            {
                WriteLine("Finalizar o bloco");
            }
        }
        #endregion

        #region Cenário 6
        public static void Executar_Cenario6(int num1, int num2, string operador)
        {
            var calculadora = new Calculadora();
            try
            {
                int resultado = calculadora.Cenario6(num1, num2, operador);
                GetResultado(resultado);
            }
            catch (ArgumentNullException error)
            {
                WriteLine($"Operação não foi informada. {error}");
            }
            catch (ArgumentOutOfRangeException error)
            {
                WriteLine($"Operação não suportado. {error}");
            }
            catch (Exception error)
            {
                WriteLine($"Ocorreu um erro inesperado. {error}");
            }
            finally
            {
                WriteLine("Finalizar o bloco");
            }
        }
        #endregion

        #region Cenário 7
        public static void Executar_Cenario7(int num1, int num2, string operador)
        {
            var calculadora = new Calculadora();
            try
            {
                int resultado = calculadora.Cenario7(num1, num2, operador);
                GetResultado(resultado);
            }
            /* Filtrar blocos de exceção */
            catch (ArgumentNullException error) when (error.ParamName == nameof(operador))
            {
                WriteLine($"Operação não foi informada. {error}");
            }
            catch (ArgumentOutOfRangeException error)
            {
                WriteLine($"Operação não suportado. {error}");
            }
            catch (Exception error)
            {
                WriteLine($"Ocorreu um erro inesperado. {error}");
            }
            finally
            {
                WriteLine("Finalizar o bloco");
            }
        }
        #endregion

        private static void GetResultado(int paramResultado)
        {
            WriteLine($"Resultado: {paramResultado}");
        }
    }

    public class Calculadora
    {
        public int Cenario1(int param1, int param2, string operador)
        {
            if (operador == "/")
            {
                return Dividir(param1, param2);
            }
            else
            {
                /* Alternativa simples de notificar uma operação irregular */
                WriteLine("Operação desconhecida.");
                return 0;
            }
        }

        public int Cenario2(int param1, int param2, string operador)
        {
            if (operador == "/")
            {
                return Dividir(param1, param2);
            }
            else
            {
                /* Modo mais flexível de notificar uma ação inesperada.
                 * Além disso, o programador poderá passar a variável (causa do erro) 
                 * como parametro de exceção. */
                throw new ArgumentOutOfRangeException(nameof(operador),
                    "O operador matemático não é suportado.");
            }
        }

        public int Cenario3(int param1, int param2, string operador)
        {
            /* Recursos C# 7 ou superior. Realizar a mesma operação do B.01, 
             * porém com uma sintaxe mais limpa. 
             * ?? Null coalescing */
            string nonNulo = operador ?? throw new ArgumentNullException(nameof(operador));

            if (operador == "/")
            {
                return Dividir(param1, param2);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(operador),
                    "O operador matemático não é suportado.");
            }
        }

        public int Cenario4(int param1, int param2, string operador)
        {
            string nonNulo = operador ?? throw new ArgumentNullException(nameof(operador));

            if (operador == "/")
            {
                return Dividir(param1, param2);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(operador),
                    "O operador matemático não é suportado.");
            }
        }

        public int Cenario5(int param1, int param2, string operador)
        {
            string nonNulo = operador ?? throw new ArgumentNullException(nameof(operador));

            if (operador == "/")
            {
                try
                {
                    return Dividir(param1, param2);
                }
                catch (DivideByZeroException error)
                {
                    /* E.01 - Rethrowing Exception 
                     * Chamado de Re-throwing a ação de repassar as exceções para 
                     * o método que invocou a ação */
                    
                    //throw error; // Abordagem não recomendada
                    throw; // Boa prática: pois não oculta informações valiosas do Stack Trace
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(operador),
                    "O operador matemático não é suportado.");
            }
        }

        public int Cenario6(int param1, int param2, string operador)
        {
            string nonNulo = operador ?? throw new ArgumentNullException(nameof(operador));

            if (operador == "/")
            {
                try
                {
                    return Dividir(param1, param2);
                }
                catch (DivideByZeroException error)
                {
                    /* Wrapping Exceptions 
                     * Evento ocorre quando o programador deseja enviar a exceção 
                     * original por meio do parametro (InnerException) */
                    //throw new ArithmeticException(); // Abordagem não recomendada
                    throw new ArithmeticException("Ocorreu um erro de aritmética", error);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(operador),
                    "O operador matemático não é suportado.");
            }
        }

        public int Cenario7(int param1, int param2, string operador)
        {
            /* Filtrar blocos de exceção */
            //operador = null;
            throw new ArgumentNullException(nameof(operador));
        }

        private int Dividir(int paramNumero, int paramDivisor)
        {
            return paramNumero / paramDivisor;
        }
    }
}
