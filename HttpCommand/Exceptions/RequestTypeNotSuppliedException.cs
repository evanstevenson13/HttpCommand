using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpCommands{
    class RequestTypeNotSuppliedException:Exception{

        public RequestTypeNotSuppliedException(){
                
        }

        public RequestTypeNotSuppliedException(string message):base(message){

        }

        public RequestTypeNotSuppliedException(string message, Exception inner):base(message, inner){

        }
    }
}
