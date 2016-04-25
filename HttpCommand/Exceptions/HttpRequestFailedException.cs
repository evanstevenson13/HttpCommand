

using System;


namespace HttpCommand{
    class HttpRequestFailedException:Exception{
        public HttpRequestFailedException(){
                
        }

        public HttpRequestFailedException(string message):base(message){

        }

        public HttpRequestFailedException(string message, Exception inner):base(message, inner){

        }

        //public override string ToString(){
        //    return StackTrace.ToString();
        //}
    }
}
