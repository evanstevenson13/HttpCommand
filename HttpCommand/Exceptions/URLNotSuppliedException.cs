using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpCommands{
    class URLNotSuppliedException:Exception{
        public URLNotSuppliedException(){
                
        }

        public URLNotSuppliedException(string message):base(message){

        }

        public URLNotSuppliedException(string message, Exception inner):base(message, inner){

        }
    }
}
