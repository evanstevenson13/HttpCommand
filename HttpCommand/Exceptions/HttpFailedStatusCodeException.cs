

using System;


namespace HttpCommand{
    /// <summary>
    /// Exception thats thrown when a failing status code is returned
    /// </summary>
    public class HttpFailedStatusCodeException : Exception{
        /// <summary>
        /// Constructor
        /// </summary>
        public HttpFailedStatusCodeException(){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        public HttpFailedStatusCodeException(string message):base(message){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        /// <param name="inner">Exception to add to this exception</param>
        public HttpFailedStatusCodeException(string message, Exception inner):base(message, inner){}
    }
}
