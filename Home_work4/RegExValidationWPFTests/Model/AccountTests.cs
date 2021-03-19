using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegExValidationWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExValidationWPF.Model.Tests
{
    [TestClass()]
    public class AccountTests
    {
        [TestMethod()]
        public void MinTest()
        {
            int min;
            min = Account.Min(3, 4, 5);
            Assert.AreEqual(3, min);
        }
    }
}