

using Microsoft.VisualStudio.TestTools.UnitTesting;
using HttpCommand;
using System;

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
    }
}
