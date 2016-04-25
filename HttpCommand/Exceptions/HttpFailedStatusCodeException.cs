using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpCommands{
    class HttpFailedStatusCodeException:Exception{
        public HttpFailedStatusCodeException(){
                
        }

        public HttpFailedStatusCodeException(string message):base(message){

        }

        public HttpFailedStatusCodeException(string message, Exception inner):base(message, inner){

        }
    }
}
