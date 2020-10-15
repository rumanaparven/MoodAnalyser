using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
using System;


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
            string message = "I am in HAPPY mood";
            Mood mood = new Mood(message);
            string actual = mood.AnalayseMood();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string expected = "string should not be null";
            string message = null;
            try
            {
                Mood mood = new Mood(message);

            }
            catch (MoodAnalyserException ce)
            {
                string actual = ce.Message;
                Assert.AreEqual(expected, actual);
            }

        }
        [TestMethod]
        public void TestMethod5()
        {
            string message = " ";
            MoodAnalyserException.TypeOfException expected = MoodAnalyserException.TypeOfException.EMPTYSTRING_ENTRY;
            try
            {
                Mood mood = new Mood(message);

            }
            catch (MoodAnalyserException ce)
            {
                Assert.AreEqual(expected, ce.type);
            }
        }
        [TestMethod]
        public void TestMethod6()
        {
            string message = null;
            Object obj = MoodAnalyzerFactory.CreateMoodAnalyse("MoodAnalyser.Mood", "Mood");
            Object expected = new Mood(message);
            obj.Equals(expected);

        }
        [TestMethod]
        public void TestMethod7()
        {
            string message = "HAPPY";
            object obj = MoodAnalyzerFactory.CreateMoodAnalyseWithParametrizedConstructor("MoodAnalyser.Mood", "Mood",message);
            object expected = new Mood(message);
            obj.Equals(expected);

        }
        [TestMethod]
        public void TestMethod8()
        {
            string obj = MoodAnalyzerFactory.InvokeMoodMethod("AnalayseMood", "Iam HAPPY");
            string expected = "HAPPY";
            Assert.AreEqual(obj, expected);

        }
    }
}
