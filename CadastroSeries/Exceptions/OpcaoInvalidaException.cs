using System;
namespace CadastroSeries.Exceptions
{
    [Serializable]
    public class OpcaoInvalidaException : ArgumentOutOfRangeException
    {
        public OpcaoInvalidaException() : base() { }
        public OpcaoInvalidaException(string msg) : base(msg) { }

        public OpcaoInvalidaException(string msg, Exception inner) : base(msg, inner) { }
    }
}