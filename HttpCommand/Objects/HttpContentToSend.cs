

using System.Net.Http;
using System.Text;


namespace HttpCommand{
    /// <summary>
    /// Object used to send content with a http request
    /// </summary>
    public class HttpContentToSend{
        private string content = string.Empty;
        private Encoding encoding = Encoding.UTF8;
        private ContentType contentType = ContentType.PostForm;


        /// <summary>
        /// Constructor that assumes you are just getting a something
        /// </summary>
        public HttpContentToSend(){}


        /// <summary>
        /// Constructor to send content and use default encoding
        /// </summary>
        /// <param name="content">Content to send</param>
        /// <param name="contentType">The content type</param>
        public HttpContentToSend(string content, ContentType contentType){
            this.content = content;
            this.contentType =  contentType;
        }


        /// <summary>
        /// Constructor to send content where you can set the encoding
        /// </summary>
        /// <param name="content">Content to send</param>
        /// <param name="encoding">Encoding to use</param>
        /// <param name="contentType">The content type</param>
        public HttpContentToSend(string content, Encoding encoding, ContentType contentType){
            this.content = content;
            this.encoding = encoding;
            this.contentType =  contentType;
        }


        /// <summary>
        /// Provides the content with nothing done to it for get requests
        /// </summary>
        /// <returns>The content string</returns>
        protected internal string GetContentString(){
            if(string.IsNullOrEmpty(content)){
                content = string.Empty;
            }
            return content;
        }

        
        /// <summary>
        /// Creates the string content to be sent with a http request
        /// </summary>
        /// <returns>The string content of the provided content</returns>
        protected internal StringContent GetContent(){
            return new StringContent(content, encoding, contentType.Value);
        }

    }
}
