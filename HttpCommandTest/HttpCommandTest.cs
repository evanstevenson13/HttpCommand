

using Microsoft.VisualStudio.TestTools.UnitTesting;
using HttpCommand;

namespace HttpCommandTest{
    [TestClass]
    public class HttpCommandTest{

        [TestMethod]
        [ExpectedException(typeof(EmptyOrInvalidUriException))]
        public void NoUrlSupplied(){
            HttpContentToSend content = new HttpContentToSend();
            HttpRequestInfo requestInfo = new HttpRequestInfo(string.Empty, RequestType.Get, content);
            HttpRunner.SendHttpRequest(requestInfo);
        }
    }
}
