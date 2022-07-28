using System.Runtime.Serialization;

namespace Async.Models
{
    public class ThreadRunParallelException : Exception
    {
        public ThreadRunParallelException()
        { }

        protected ThreadRunParallelException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }

        public ThreadRunParallelException(string? message) : base(message)
        { }

        public ThreadRunParallelException(string? message, Exception? innerException) : base(message, innerException)
        { }
    }
}