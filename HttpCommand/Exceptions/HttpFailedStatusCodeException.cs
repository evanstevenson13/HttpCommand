

using System;


namespace HttpCommand{
    class HttpFailedStatusCodeException:Exception{
        public HttpFailedStatusCodeException(){
                
        }

        public HttpFailedStatusCodeException(string message):base(message){

        }

        public HttpFailedStatusCodeException(string message, Exception inner):base(message, inner){

        }
    }
}
