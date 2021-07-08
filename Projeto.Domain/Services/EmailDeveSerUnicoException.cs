using System;
using System.Runtime.Serialization;

namespace Projeto.Domain.Services
{
    [Serializable]
    internal class EmailDeveSerUnicoException : Exception
    {
        public EmailDeveSerUnicoException()
        {
        }

        public EmailDeveSerUnicoException(string message) : base(message)
        {
        }

        public EmailDeveSerUnicoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmailDeveSerUnicoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}