using System;

namespace CadastroSeries.Exceptions
{
    [Serializable]
    public class ListaVaziaException : Exception
    {
        public ListaVaziaException() : base() { }
        public ListaVaziaException(string msg) : base(msg) { }
        public ListaVaziaException(string msg, Exception inner) : base(msg, inner) { }

    }
}