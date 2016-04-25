

using System;
using System.Net.Http.Headers;
using System.Text;


namespace HttpCommands.Objects{
    /// <summary>
    /// Authentication that can be sent with an http request
    /// </summary>
    public class AuthenticationHeader{
        private string username = string.Empty;
        private string password = string.Empty;


        /// <summary>
        /// Create an authentication object
        /// </summary>
        /// <param name="username">Username of the authentication object</param>
        /// <param name="password">Password of the authentication object</param>
        public AuthenticationHeader(string username, string password){
            this.username = username;
            this.password = password;
        }


        /// <summary>
        /// Creates the authentication object and returns it
        /// </summary>
        /// <returns>The authentication object</returns>
        public AuthenticationHeaderValue GetHeader(){
            byte[] encodedValues = Encoding.ASCII.GetBytes(string.Concat(username, ":", password));
            return new AuthenticationHeaderValue("Authorization", Convert.ToBase64String(encodedValues));
        }
    }
}
