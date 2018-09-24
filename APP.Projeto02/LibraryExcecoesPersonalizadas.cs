using System;

namespace APP.Excecao02
{
    public class CalcularException : Exception
    {
        private static readonly string MensagemPadrao = "Ocorreu um erro durante o cálculo";

        public CalcularException() : base(MensagemPadrao) { }

        public CalcularException(string mensagem) : base(mensagem) { }

        public CalcularException(Exception innerException) : base(MensagemPadrao, innerException) { }

        public CalcularException(string mensagem, Exception innerException) : base(mensagem, innerException) { }
    }

    public class CalcularOperacaoNaoSuportadaException : CalcularException
    {
        private static readonly string MensagemPadrao = "Operador informado não é suportado";

        public string Operador { get; }
        public override string Message
        {
            get
            {
                string message = base.Message;

                if (Operador != null)
                {
                    return message + Environment.NewLine +
                        $"Operação não suportada: {Operador}";
                }

                return message;
            }
        }

        public CalcularOperacaoNaoSuportadaException() : base(MensagemPadrao) { }

        public CalcularOperacaoNaoSuportadaException(string operador) : this()
        {
            Operador = operador;
        }

        public CalcularOperacaoNaoSuportadaException(string mensagem, Exception innerException) 
            : base(mensagem, innerException) { }

        public CalcularOperacaoNaoSuportadaException(string operador, string mensagem)
            : base (mensagem)
        {
            Operador = operador;
        }
    }
}
