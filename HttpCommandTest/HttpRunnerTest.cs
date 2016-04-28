

using Microsoft.VisualStudio.TestTools.UnitTesting;
using HttpCommand;

namespace HttpRunnerTest{
    [TestClass]
    public class HttpRunnerTest{

        [TestMethod]
        [ExpectedException(typeof(EmptyOrInvalidUriException))]
        public void NoUrlSupplied(){
            HttpContentToSend content = new HttpContentToSend();
            HttpRequestInfo requestInfo = new HttpRequestInfo(string.Empty, RequestType.Get, content);
            HttpRunner.SendHttpRequest(requestInfo);
        }


        [TestMethod]
        public void UrlSupplied(){
            HttpContentToSend content = new HttpContentToSend();
            HttpRequestInfo requestInfo = new HttpRequestInfo("http://www.google.com", RequestType.Get, content);
            HttpRunner.SendHttpRequest(requestInfo);
        }


        [TestMethod]
        public void UrlSuppliedWithPort(){
            HttpContentToSend content = new HttpContentToSend();
            HttpRequestInfo requestInfo = new HttpRequestInfo("http://www.google.com:80", RequestType.Get, content);
            HttpRunner.SendHttpRequest(requestInfo);
        }


        [TestMethod]
        public void UrlSuppliedWithPortAndAuthentication(){
            HttpContentToSend content = new HttpContentToSend();
            HttpRequestInfo requestInfo = new HttpRequestInfo("http://www.google.com:80", RequestType.Get, content, new HttpCommands.Objects.AuthenticationHeader("username", "password"));
            HttpRunner.SendHttpRequest(requestInfo);
        }
    }
}
