using System;


using System.Reflection;

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

        public static object CreateMoodAnalyseWithParametrizedConstructor(string className, string constructor,string message)
        {
            Type type = typeof(Mood);

            if (type.Name.Equals(className)|| type.FullName.Equals(className))
            {
                if(type.Name.Equals(constructor))
                {
                    ConstructorInfo cons = type.GetConstructor(new[] { typeof(string) });
                    object instance = cons.Invoke(new object[] { message });
                    return instance;
                }
                else 
                {
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_SUCH_METHOD, "Constructor not found"); 
                }

            }
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_SUCH_CLASS, "Class not found");
            }
        }
        public static string InvokeMoodMethod(string methodName,string message)
        {
            
            try
            {
                Type type = typeof(Mood);
                object MoodObject = MoodAnalyzerFactory.CreateMoodAnalyseWithParametrizedConstructor(type.FullName, type.Name,message);
                MethodInfo method = type.GetMethod(methodName);
                object instance = method.Invoke(MoodObject,null);
                return instance.ToString();
            }
           
            catch(NullReferenceException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_SUCH_METHOD, "method not found");
            }
        }
        public static string SetMoodDynamically(string message,string fieldName)
        {
            try
            {
                if (message == null)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NULL_ENTRY, "null entry");
                }
                Mood obj = new Mood();
                Type type = typeof(Mood);
                FieldInfo field = type.GetField(fieldName);
                field.SetValue(obj, message);
                return obj.message;
            }
            catch(NullReferenceException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NO_SUCH_FIELD, "Field not found");
            }
        }
    }
}
