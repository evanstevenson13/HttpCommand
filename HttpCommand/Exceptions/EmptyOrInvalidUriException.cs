

using System;


namespace HttpCommand{
    /// <summary>
    /// Exception thats thrown when a invalid or empty url is supplied
    /// </summary>
    public class EmptyOrInvalidUriException : Exception{
        /// <summary>
        /// Constructor
        /// </summary>
        public EmptyOrInvalidUriException(){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        public EmptyOrInvalidUriException(string message):base(message){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        /// <param name="inner">Exception to add to this exception</param>
        public EmptyOrInvalidUriException(string message, Exception inner):base(message, inner){}
    }
}
