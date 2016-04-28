

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
        private RequestType requestType = RequestType.Get;
        private HttpContentToSend content = null;
        private AuthenticationHeader authentication = null;

        
        /// <summary>
        /// Constructor - Get request
        /// </summary>
        /// <param name="url">Url to request</param>
        /// <param name="requestType">Request type to send request as</param>
        public HttpRequestInfo(string url, RequestType requestType){
            this.url = url;
            this.requestType = requestType;
        }

        
        /// <summary>
        /// Constructor - Get request with authentication
        /// </summary>
        /// <param name="url">Url to request</param>
        /// <param name="requestType">Request type to send request as</param>
        /// <param name="authentication">Authentication to use</param>
        public HttpRequestInfo(string url, RequestType requestType, AuthenticationHeader authentication){
            this.url = url;
            this.requestType = requestType;
            this.authentication = authentication;
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url">Url to request</param>
        /// <param name="requestType">Request type to send request as</param>
        /// <param name="content">Content to send</param>
        public HttpRequestInfo(string url, RequestType requestType, HttpContentToSend content){
            this.url = url;
            this.requestType = requestType;
            this.content = content;
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url">Url to request</param>
        /// <param name="requestType">Request type to send request as</param>
        /// <param name="content">Content to send</param>
        /// <param name="authentication">Authentication to use</param>
        public HttpRequestInfo(string url, RequestType requestType, HttpContentToSend content, AuthenticationHeader authentication) : this(url, requestType, content){
            this.authentication = authentication;
        }


        /// <summary>
        /// Checks to see if the provided url is valid, returns null if it isn't
        /// </summary>
        /// <returns>A uri for the provided url or null if the url was invalid</returns>
        public Uri GetURI(){
            Uri uriResult = null;
            if(Uri.TryCreate(url, UriKind.Absolute, out uriResult)){
                if(uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps){
                    uriResult = null;
                }
                //IP address come up as unknown -> Uri.CheckHostName(url) == UriHostNameType.Unknown
                if(Uri.CheckHostName(url) == UriHostNameType.Basic){
                    uriResult=null;
                }
            }
            if(uriResult != null && requestType == RequestType.Get && content != null){
                if(!string.IsNullOrEmpty(url)&&!string.IsNullOrEmpty(content.GetContentString())){
                    uriResult = new Uri(uriResult, string.Concat("?", content.GetContentString()));
                }
            }
            return uriResult;
        }


        /// <summary>
        /// Get the request type
        /// </summary>
        /// <returns>The request to send</returns>
        protected internal RequestType GetRequestType(){
            return requestType;
        }


        /// <summary>
        /// Get the content object to send
        /// </summary>
        /// <returns>Content object to send</returns>
        protected internal HttpContentToSend GetContent(){
            return content;
        }


        /// <summary>
        /// Gets the authentication header to be sent with the request
        /// </summary>
        /// <returns>A authentication header with the supplied username and password</returns>
        public AuthenticationHeaderValue GetHeader(){
            if(authentication == null){
                return null;
            }
            return authentication.GetHeader();
        }
    }
}
