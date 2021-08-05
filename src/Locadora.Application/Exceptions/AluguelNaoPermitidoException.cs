using System;
using System.Runtime.Serialization;
using Locadora.Domain.Entidades;

namespace Locadora.Application.Exceptions
{
    [Serializable]
    public class AluguelNaoPermitidoException : Exception
    {
        public AluguelNaoPermitidoException() : base() 
        {
        }

        public AluguelNaoPermitidoException(string tituloProduto) : base(tituloProduto + " não está disponível para aluguel")
        {
        }

        public AluguelNaoPermitidoException(string tituloProduto, Exception inner) : base(tituloProduto + " não está disponível para aluguel", inner)
        {
        }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected AluguelNaoPermitidoException(SerializationInfo info, StreamingContext context) : base(info, context) 
        {
        }
    }
}