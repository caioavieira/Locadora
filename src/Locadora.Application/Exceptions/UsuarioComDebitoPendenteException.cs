using System;
using System.Runtime.Serialization;

namespace Locadora.Application.Exceptions
{
    [Serializable]
    public class UsuarioComDebitoPendenteException : Exception
    {
        public UsuarioComDebitoPendenteException() : base() 
        {
        }

        public UsuarioComDebitoPendenteException(string nomeUsuario) : base(nomeUsuario + " contem débitos pendentes")
        {
        }

        public UsuarioComDebitoPendenteException(string nomeUsuario, Exception inner) : base(nomeUsuario + " contem débitos pendentes", inner)
        {
        }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected UsuarioComDebitoPendenteException(SerializationInfo info, StreamingContext context) : base(info, context) 
        {
        }
    }
}