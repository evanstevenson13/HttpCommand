

using HttpCommands.Objects;
using System.Net.Http.Headers;

namespace HttpCommand{

    //todo maybe....ping url to see if its alive
    //todo check for valid url as well as the rest of the data
    /// <summary>
    /// Object that holds all the data needed to send a http request
    /// </summary>
    public class HttpRequestInfo{
        private string url;
        private RequestType type;
        private HttpContentToSend content;
        private AuthenticationHeader authentHeader = null;

        public HttpRequestInfo(string url, RequestType type, HttpContentToSend content){
            this.url = url;
            this.type = type;
            this.content = content;
        }

        public HttpRequestInfo(string url, RequestType type, HttpContentToSend content, AuthenticationHeader authentication) : this(url, type, content){
            this.authentHeader = authentication;
        }

        protected internal string GetURL(){
            return url;
        }

        protected internal RequestType GetRequestType(){
            return type;
        }

        protected internal HttpContentToSend GetContent(){
            return content;
        }

        protected internal AuthenticationHeaderValue GetHeader(){
            if(authentHeader == null){
                return null;
            }
            return authentHeader.GetHeader();
        }
    }
}
