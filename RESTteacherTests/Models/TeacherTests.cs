using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTteacher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTteacher.Models.Tests
{
    [TestClass()]
    public class TeacherTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            Teacher teacher = new Teacher() { Id = 1 };

            teacher.Name = "Bobo";
            Assert.AreEqual("Bobo", teacher.Name);
            Assert.ThrowsException<ArgumentException>(() => teacher.Name = "Bob");
            Assert.ThrowsException<ArgumentNullException>(() => teacher.Name = null);

            teacher.Salary = 0;
            Assert.AreEqual(0, teacher.Salary);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => teacher.Salary = -1);

            Assert.AreEqual("1 Anders 0", teacher.ToString());
        }
    }
}