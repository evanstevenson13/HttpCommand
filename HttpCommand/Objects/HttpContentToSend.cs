

using System.Net.Http;
using System.Text;


namespace HttpCommand{
    public class HttpContentToSend{
        private string content = string.Empty;
        private Encoding encod = Encoding.UTF8;
        private string contentType = ContentType.PostForm;

        public HttpContentToSend(string c, Encoding e, string ct){
            content = c;
            encod = e;
            contentType =  ct;
        }


        protected internal string GetContentString(){
            return content;
        }

        
        protected internal StringContent GetContent(){
            //if (contentType == ContentType.GetForm){
            //    return content;
            //}
            return new StringContent(content, encod, contentType);
        }

    }
}
