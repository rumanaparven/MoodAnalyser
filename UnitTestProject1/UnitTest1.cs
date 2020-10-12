using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string expected = "SAD";
            string message = "I am SAD";
            Mood mood = new Mood(message);
            string actual = mood.AnalayseMood();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string expected = "HAPPY";
            string message = "I am in any mood";
            Mood mood = new Mood(message);
            string actual = mood.AnalayseMood();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod3()
        {
            string expected = "SAD";
            string message = "I am in HAPPY mood";
            Mood mood = new Mood(message);
            string actual = mood.AnalayseMood();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod4()
        {
            string expected = "HAPPY";
            string message = null;
            Mood mood = new Mood(message);
            string actual = mood.AnalayseMood();
            Assert.AreEqual(expected, actual);
        }

    }
}
