using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CaesarsСipher;

namespace CaesarsСipherUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string password = "qwerty";
            string exceptCPass = "rxfsuz";

            string cpass = CodePassword.getCodPassword(password);
            Assert.AreEqual(exceptCPass, cpass);            
        }

        [TestMethod]
        public void TestMethod2()
        {
            string password = "qwerty";
            string exceptCPass = "rxfsuz";
                        
            string epass = CodePassword.getPassword(exceptCPass);
            Assert.AreEqual(password, epass);
        }
    }
}
