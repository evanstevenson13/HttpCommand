

using HttpCommands.Objects;
using System;
using System.Net.Http.Headers;


namespace HttpCommand{
    //todo maybe....ping url to see if its alive
    //todo check for valid url as well as the rest of the data
    /// <summary>
    /// Object that holds all the data needed to send an http request
    /// </summary>
    public class HttpRequestInfo{
        private string url = string.Empty;
        private RequestType type = RequestType.Get;
        private HttpContentToSend content = null;
        private AuthenticationHeader authentication = null;

        public HttpRequestInfo(string url, RequestType type, HttpContentToSend content){
            this.url = url;
            this.type = type;
            this.content = content;
        }

        public HttpRequestInfo(string url, RequestType type, HttpContentToSend content, AuthenticationHeader authentication) : this(url, type, content){
            this.authentication = authentication;
        }

        protected internal string GetURL(){
            return url;
        }


        /// <summary>
        /// Checks to see if the provided url is valid, returns null if it isn't
        /// </summary>
        /// <returns>A uri for the provided url or null if the url was invalid</returns>
        public Uri GetURI(){
            Uri uriResult;
            if(Uri.TryCreate(url, UriKind.Absolute, out uriResult)){
                if(uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps){
                    if(Uri.CheckHostName(url) != UriHostNameType.Basic || Uri.CheckHostName(url) != UriHostNameType.Unknown){
                        return uriResult;
                    }
                }
            }
            return null;
        }

        protected internal RequestType GetRequestType(){
            return type;
        }

        protected internal HttpContentToSend GetContent(){
            return content;
        }

        public AuthenticationHeaderValue GetHeader(){
            if(authentication == null){
                return null;
            }
            return authentication.GetHeader();
        }
    }
}
