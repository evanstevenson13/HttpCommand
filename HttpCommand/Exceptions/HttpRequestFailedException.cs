

using System;


namespace HttpCommand{
    /// <summary>
    /// Exception thats thrown when a request fails
    /// </summary>
    public class HttpRequestFailedException : Exception{
        /// <summary>
        /// Constructor
        /// </summary>
        public HttpRequestFailedException(){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        public HttpRequestFailedException(string message):base(message){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        /// <param name="inner">Exception to add to this exception</param>
        public HttpRequestFailedException(string message, Exception inner):base(message, inner){}
    }
}
