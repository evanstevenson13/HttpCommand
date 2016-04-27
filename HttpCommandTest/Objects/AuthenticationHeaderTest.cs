

using HttpCommands.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http.Headers;
using System.Text;


namespace HttpCommandTest{
    [TestClass]
    public class AuthenticationHeaderTest{

        [TestMethod]
        public void GetAuthenticationHeaderValue(){
            byte[] encodedValues = Encoding.ASCII.GetBytes(string.Concat("admin", ":", "password"));
            AuthenticationHeaderValue header = new AuthenticationHeaderValue("Authorization", Convert.ToBase64String(encodedValues));
            
            AuthenticationHeader authToSend = new AuthenticationHeader("admin", "password");
            Assert.IsNotNull(authToSend.GetHeader());
            Assert.AreEqual(header, authToSend.GetHeader());
        }


        [TestMethod]
        public void PassNullUsernameAndPassword(){            
            AuthenticationHeader authToSend = new AuthenticationHeader(string.Empty, string.Empty);
            Assert.IsNull(authToSend.GetHeader());
        }


        [TestMethod]
        public void PassNullUsername(){            
            AuthenticationHeader authToSend = new AuthenticationHeader(string.Empty, "password");
            Assert.IsNull(authToSend.GetHeader());
        }


        [TestMethod]
        public void PassNullPassword(){            
            AuthenticationHeader authToSend = new AuthenticationHeader("username", string.Empty);
            Assert.IsNull(authToSend.GetHeader());
        }
    }
}
