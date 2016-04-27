

using System;


namespace HttpCommand{
    public class EmptyOrInvalidUriException:Exception{
        public EmptyOrInvalidUriException(){
                
        }

        public EmptyOrInvalidUriException(string message):base(message){

        }

        public EmptyOrInvalidUriException(string message, Exception inner):base(message, inner){

        }
    }
}
