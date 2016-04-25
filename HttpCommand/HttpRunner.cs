

using HttpCommands.Objects;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;


namespace HttpCommands{
    /// <summary>
    /// Can be used to send different types of http requests
    /// </summary>
    public class HttpRunner{        


        /// <summary>
        /// Sends a http request
        /// </summary>
        /// <param name="data">The data needed for sending the request(url, type, ...)</param>
        /// <returns>String response from the http request</returns>
        /// <exception cref="URLNotSuppliedException">No Url was supplied</exception>
        /// <exception cref="HttpRequestFailedException">Error happened when attempting to send request</exception>
        /// <exception cref="HttpFailedStatusCodeException">A bad status was returned from the request</exception>
        public string SendHttpRequest(HttpRequestInfo data){
            string responseText = string.Empty;
            string url = data.GetURL();
            RequestType type = data.GetRequestType();
            HttpContentToSend content = data.GetContent();

            if(string.IsNullOrEmpty(url)){
                throw new URLNotSuppliedException("No url was specified");
            }

            using (HttpClient client = new HttpClient()){
                if(data.GetHeader() == null){
                    //todo make authorization work
                    client.DefaultRequestHeaders.Authorization = data.GetHeader();
                }

                    
                    /*  Ignore bad certificates -- Remove for production */
                //todo make certificates work
                ServicePointManager.ServerCertificateValidationCallback = delegate{return true;};
                HttpResponseMessage response=null;
                    // Request times out after 5 seconds
                    //todo Add in option to pass in timeout
                //client.Timeout = new TimeSpan(0, 0, 5);

                try{
                    if(type == RequestType.Get){
                        url = string.Concat(url, "?", content.GetContentString());
                        response  = client.GetAsync(url).Result;
                    }else if(type == RequestType.Post){
                        response  = client.PostAsync(url, content.GetContent()).Result;
                    }else if(type == RequestType.Put){
                        response  = client.PutAsync(url, content.GetContent()).Result;
                    }else if(type == RequestType.Delete){
                        response  = client.DeleteAsync(url).Result;
                    }else{
                        response  = client.GetAsync(url).Result;
                    }
                }catch(Exception excep){
                    throw new HttpRequestFailedException("Http request could not be finished, likely a bad/unreachable url("+url+")", excep);
                }

                if(response.IsSuccessStatusCode){
                    using(HttpContent responseContent = response.Content){
                        responseText = responseContent.ReadAsStringAsync().Result;
                    }
                }else{
                    //throw new HttpFailedStatusCodeException("Http request returned failing status code" + response.StatusCode);
                    throw new HttpFailedStatusCodeException(responseText + response.StatusCode);
                }
            }
            return responseText;
        }
    }// SendHttpRequest


    //todo ping url to see if its alive
    //todo check for valid url as well as the rest of the data
    /// <summary>
    /// Object that holds all the data needed to send a http request
    /// </summary>
    public class HttpRequestInfo{
        private string url;
        private RequestType type;
        private HttpContentToSend content;
        private AuthenticationHeader authentHeader = null;

        public HttpRequestInfo(string u, RequestType t ,HttpContentToSend c){
            url = u;
            type = t;
            content = c;
        }

        public HttpRequestInfo(string u ,RequestType t ,HttpContentToSend c, AuthenticationHeader ah) : this(u, t, c){
            authentHeader=ah;
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

    public sealed class ContentType{
        public const string PostForm = "application/x-www-form-urlencoded";
        //public const string GetForm = "";
        public const string Json = "application/json"; //"application/json";
        public const string FormData = "multipart/form-data";
        public const string TextHTML = "text/html";
    }


    public enum RequestType{
        Get,
        Post,
        Put,
        Delete,
    }


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
}// HttpCommands Namespace
