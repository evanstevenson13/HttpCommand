﻿

using System;
using System.Net;
using System.Net.Http;


namespace HttpCommand{
    /// <summary>
    /// Can be used to send different types of http requests
    /// </summary>
    public static class HttpRunner{
        /// <summary>
        /// Sends a http request
        /// </summary>
        /// <param name="data">The data needed for sending the request(url, type, ...)</param>
        /// <returns>String response from the http request</returns>
        /// <exception cref="URLNotSuppliedException">No Url was supplied</exception>
        /// <exception cref="HttpRequestFailedException">Error happened when attempting to send request</exception>
        /// <exception cref="HttpFailedStatusCodeException">A bad status was returned from the request</exception>
        public static string SendHttpRequest(HttpRequestInfo data){
            string responseText = string.Empty;
            //string url = data.GetURL();
            Uri requestUri = data.GetURI();
            RequestType type = data.GetRequestType();
            HttpContentToSend content = data.GetContent();

            if(data.GetURI() == null){
                throw new EmptyOrInvalidUriException("No url was specified");
            }

            using (HttpClient client = new HttpClient()){
                if(data.GetHeader() == null){
                    //todo make authorization work
                    client.DefaultRequestHeaders.Authorization = data.GetHeader();
                }

                    
                    /*  Ignore bad certificates -- Remove for production */
                //todo make certificates work
                ServicePointManager.ServerCertificateValidationCallback = delegate{return true;};
                HttpResponseMessage response = null;
                    // Request times out after 5 seconds
                    //todo Add in option to pass in timeout
                //client.Timeout = new TimeSpan(0, 0, 5);

                try{
                    if(type == RequestType.Get){
                        requestUri = new Uri(requestUri, string.Concat("?", content.GetContentString()));
                        response  = client.GetAsync(requestUri).Result;
                    }else if(type == RequestType.Post){
                        response  = client.PostAsync(requestUri, content.GetContent()).Result;
                    }else if(type == RequestType.Put){
                        response  = client.PutAsync(requestUri, content.GetContent()).Result;
                    }else if(type == RequestType.Delete){
                        response  = client.DeleteAsync(requestUri).Result;
                    }else{
                        response  = client.GetAsync(requestUri).Result;
                    }
                }catch(Exception excep){
                    throw new HttpRequestFailedException("Http request could not be finished, likely a bad/unreachable url("+ requestUri.ToString() +")", excep);
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
    
}// HttpCommands Namespace
