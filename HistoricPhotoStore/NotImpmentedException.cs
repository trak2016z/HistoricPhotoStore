using System;
using System.Runtime.Serialization;

namespace HistoricPhotoStore
{
    [Serializable]
    internal class NotImpmentedException : Exception
    {
        public NotImpmentedException()
        {
        }

        public NotImpmentedException(string message) : base(message)
        {
        }

        public NotImpmentedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotImpmentedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}