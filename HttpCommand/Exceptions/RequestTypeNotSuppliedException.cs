

using System;


namespace HttpCommand{
    /// <summary>
    /// Exception thats thrown when a request type is not supplied
    /// </summary>
    public class RequestTypeNotSuppliedException : Exception{
        /// <summary>
        /// Constructor
        /// </summary>
        public RequestTypeNotSuppliedException(){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        public RequestTypeNotSuppliedException(string message):base(message){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        /// <param name="inner">Exception to add to this exception</param>
        public RequestTypeNotSuppliedException(string message, Exception inner):base(message, inner){}
    }
}
