using System;
using System.IO;
using System.Threading.Tasks;

namespace APP.Projeto03
{
    class Program
    {
        static void Main(string[] args)
        {
            Executar();           
        }

        static async void Executar()
        {
            try
            {
                throw new Exception("Ocorreu um erro inesperado");
            }
            catch (Exception ex)
            {
                await SetLogging("Descrição do problema: ", ex);
            }
            finally
            {
                await SetLogging("Logging complete", null);
            }
        }

        static async Task SetLogging(string detalhe, Exception error)
        {
            using (var arquivoLog = File.AppendText("erros.log"))
            {
                await arquivoLog.WriteLineAsync($"{detalhe} {error?.ToString()}");
            }
        }
    }
}
