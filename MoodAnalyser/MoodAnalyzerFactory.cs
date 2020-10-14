using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyser
{
    public class MoodAnalyzerFactory
    {
        public static object CreateMoodAnalyse(string className,string constructor)
        {
            string pattern = @"." + constructor + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch(ArgumentNullException)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_SUCH_CLASS, "Class not found");
                }

            }
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_SUCH_METHOD, "Constructor not found");
            }
        }
    }
}
