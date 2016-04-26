

using Microsoft.VisualStudio.TestTools.UnitTesting;
using HttpCommand;
using System;
using System.Net.Http.Headers;
using System.Text;
using HttpCommands.Objects;

namespace HttpCommandTest{
    [TestClass]
    public class HttpRequestInfoTest{        
        [TestMethod]
        public void InvalidEmptyURL(){
            HttpRequestInfo requestInfo = new HttpRequestInfo(string.Empty, RequestType.Get, null);
            Assert.IsNull(requestInfo.GetURI());
        }


        [TestMethod]
        public void InvalidURLWithOnlyDomain(){
            string URL = "ADomainHere";
            HttpRequestInfo requestInfo = new HttpRequestInfo(URL, RequestType.Get, null);
            Assert.IsNull(requestInfo.GetURI());
        }


        [TestMethod]
        public void InvalidURLWithOutTopLevelDomainButStillValid(){
            String URL = "http://ADomainHere";
            HttpRequestInfo requestInfo = new HttpRequestInfo(URL, RequestType.Get, null);
            Assert.IsNotNull(requestInfo.GetURI());
            Assert.AreEqual(new Uri(URL), requestInfo.GetURI());
        }


        [TestMethod]
        public void InvalidURLWithTopLevelDomain(){
            string URL = "ADomainHere.com";
            HttpRequestInfo requestInfo = new HttpRequestInfo(URL, RequestType.Get, null);
            Assert.IsNull(requestInfo.GetURI());
        }


        [TestMethod]
        public void ValidURL(){
            string URL = "http://google.com";
            HttpRequestInfo requestInfo = new HttpRequestInfo(URL, RequestType.Get, null);
            Assert.IsNotNull(requestInfo.GetURI());
            Assert.AreEqual(new Uri(URL), requestInfo.GetURI());
        }


        [TestMethod]
        public void ValidHTTPURL(){
            string URL = "http://www.google.com";
            HttpRequestInfo requestInfo = new HttpRequestInfo(URL, RequestType.Get, null);
            Assert.IsNotNull(requestInfo.GetURI());
            Assert.AreEqual(new Uri(URL), requestInfo.GetURI());
        }


        [TestMethod]
        public void ValidHTTPSURL(){
            string URL = "https://www.google.com";
            HttpRequestInfo requestInfo = new HttpRequestInfo(URL, RequestType.Get, null);
            Assert.IsNotNull(requestInfo.GetURI());
            Assert.AreEqual(new Uri(URL), requestInfo.GetURI());
        }


        [TestMethod]
        public void InvalidIPAddressNoProtocol(){
            string URL = "127.0.0.1";
            HttpRequestInfo requestInfo = new HttpRequestInfo(URL, RequestType.Get, null);
            Assert.IsNull(requestInfo.GetURI());
        }


        [TestMethod]
        public void InvalidIPAddressButStillValid(){
            string URL = "http://1277777.0.0.1";
            HttpRequestInfo requestInfo = new HttpRequestInfo(URL, RequestType.Get, null);
            Assert.IsNotNull(requestInfo.GetURI());
            Assert.AreEqual(new Uri(URL), requestInfo.GetURI());
        }


        [TestMethod]
        public void ValidHTTPIPAddress(){
            string URL = "http://127.0.0.1";
            HttpRequestInfo requestInfo = new HttpRequestInfo(URL, RequestType.Get, null);
            Assert.IsNotNull(requestInfo.GetURI());
            Assert.AreEqual(new Uri(URL), requestInfo.GetURI());
        }


        [TestMethod]
        public void ValidHTTPSIPAddress(){
            string URL = "http://127.0.0.1";
            HttpRequestInfo requestInfo = new HttpRequestInfo(URL, RequestType.Get, null);
            Assert.IsNotNull(requestInfo.GetURI());
            Assert.AreEqual(new Uri(URL), requestInfo.GetURI());
        }


        [TestMethod]
        public void PassNullAuthenticationHeader(){
            byte[] encodedValues = Encoding.ASCII.GetBytes(string.Concat("admin", ":", "password"));
            AuthenticationHeaderValue header = new AuthenticationHeaderValue("Authorization", Convert.ToBase64String(encodedValues));
            
            HttpRequestInfo requestInfo = new HttpRequestInfo(string.Empty, RequestType.Get, null, null);
            Assert.IsNull(requestInfo.GetHeader());
        }


        [TestMethod]
        public void GetAuthenticationHeader(){
            byte[] encodedValues = Encoding.ASCII.GetBytes(string.Concat("admin", ":", "password"));
            AuthenticationHeaderValue header = new AuthenticationHeaderValue("Authorization", Convert.ToBase64String(encodedValues));
            
            AuthenticationHeader authToSend = new AuthenticationHeader("admin", "password");
            HttpRequestInfo requestInfo = new HttpRequestInfo(string.Empty, RequestType.Get, null, authToSend);
            Assert.IsNotNull(requestInfo.GetHeader());
            Assert.AreEqual(header, requestInfo.GetHeader());
        }


        [TestMethod]
        public void GetRequestWithParameters(){
            Uri testUri = new Uri("http://google.com?username=AUser&password=APass");
            HttpContentToSend content = new HttpContentToSend("username=AUser&password=APass", ContentType.GetForm);
            HttpRequestInfo requestInfo = new HttpRequestInfo("http://google.com", RequestType.Get, content);
            Assert.IsNotNull(requestInfo.GetURI());
            Assert.AreEqual(testUri, requestInfo.GetURI());
        }
    }
}
