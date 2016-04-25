

using System;


namespace HttpCommand{
    class URLNotSuppliedException:Exception{
        public URLNotSuppliedException(){
                
        }

        public URLNotSuppliedException(string message):base(message){

        }

        public URLNotSuppliedException(string message, Exception inner):base(message, inner){

        }
    }
}
