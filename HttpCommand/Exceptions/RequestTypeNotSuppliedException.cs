

using System;


namespace HttpCommand{
    class RequestTypeNotSuppliedException:Exception{

        public RequestTypeNotSuppliedException(){
                
        }

        public RequestTypeNotSuppliedException(string message):base(message){

        }

        public RequestTypeNotSuppliedException(string message, Exception inner):base(message, inner){

        }
    }
}
