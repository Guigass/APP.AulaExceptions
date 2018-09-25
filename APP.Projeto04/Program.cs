using HtmlAgilityPack;
using Polly;
using System;
using System.Diagnostics;
using System.Net;

namespace APP.Projeto04
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cenario_1();

            //Cenario_2();

            //Cenario_3();

            //Cenario_4();

            //Cenario_5();

            Cenario_6();

            Console.ReadLine();
        }

        private static void Cenario_6()
        {
            Policy.Handle<WebException>().WaitAndRetry(new []
            {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(10),
                TimeSpan.FromSeconds(25)
            }, (error, tempo) =>
            {
                Debug.WriteLine(error.Message);
                Debug.WriteLine($"Tipo de exeção: {error.GetType().Name}, depois de: {tempo}. Horário: {DateTime.Now}");
            })
            .Execute(() =>
            {
                using (var webclient = new WebClient())
                {
                    string conexao = webclient.DownloadString("https://fiapmobappsfsm.azurewebsites.net/");
                    HtmlDocument htmlParse = new HtmlDocument();
                    htmlParse.LoadHtml(conexao);

                    Console.WriteLine(htmlParse.DocumentNode.SelectSingleNode("//title").InnerText);
                }
            });
        }

        private static void Cenario_5()
        {
            Policy.Handle<WebException>().Retry(10, (error, retryCount) =>
            {
                Debug.WriteLine(error.Message);
                Debug.WriteLine($"Ocorreu um erro inesperado. Tentativas: {retryCount}");
            })
            .Execute(() =>
            {
                using (var webclient = new WebClient())
                {
                    string conexao = webclient.DownloadString("https://fiapmobappsfsm.azurewebsites.net/");
                    HtmlDocument htmlParse = new HtmlDocument();
                    htmlParse.LoadHtml(conexao);

                    Console.WriteLine(htmlParse.DocumentNode.SelectSingleNode("//title").InnerText);
                }
            });
        }

        private static void Cenario_4()
        {
            Policy.Handle<WebException>().RetryForever(error =>
            {
                Debug.WriteLine(error.Message);
            })
            .Execute(() =>
            {
                using (var webclient = new WebClient())
                {
                    string conexao = webclient.DownloadString("https://fiapmobappsfsm.azurewebsites.net/");
                    HtmlDocument htmlParse = new HtmlDocument();
                    htmlParse.LoadHtml(conexao);

                    Console.WriteLine(htmlParse.DocumentNode.SelectSingleNode("//title").InnerText);
                }
            });
        }

        private static void Cenario_3()
        {
            bool isExecutado = false;

            while (!isExecutado)
            {
                try
                {
                    using (var webclient = new WebClient())
                    {
                        string conexao = webclient.DownloadString("https://fiapmobappsfsm.azurewebsites.net/");
                        HtmlDocument htmlParse = new HtmlDocument();
                        htmlParse.LoadHtml(conexao);

                        Console.WriteLine(htmlParse.DocumentNode.SelectSingleNode("//title").InnerText);
                        isExecutado = true;
                    }
                }
                catch (WebException)
                {
                    Debug.WriteLine("Ocorreu um erro inesperado.");
                }
            }
        }

        private static void Cenario_2()
        {
            try
            {
                var webclient = new WebClient();

                string conexao = webclient.DownloadString("https://fiapmobappsfsm.azurewebsites.net/");
                HtmlDocument htmlParse = new HtmlDocument();
                htmlParse.LoadHtml(conexao);

                Console.WriteLine(htmlParse.DocumentNode.SelectSingleNode("//title").InnerText);
            }
            catch (WebException)
            {
                Console.WriteLine("Ocorreu um erro inesperado.");
            }
        }

        private static void Cenario_1()
        {
            var webclient = new WebClient();

            string conexao = webclient.DownloadString("https://fiapmobappsfsm.azurewebsites.net/");
            HtmlDocument htmlParse = new HtmlDocument();
            htmlParse.LoadHtml(conexao);

            Console.WriteLine(htmlParse.DocumentNode.SelectSingleNode("//title").InnerText);
        }
    }
}
