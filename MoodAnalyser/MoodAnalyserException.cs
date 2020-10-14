using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserException: Exception
    {
        public enum TypeOfException
        {
            NULL_ENTRY, EMPTYSTRING_ENTRY, NO_SUCH_METHOD, NO_SUCH_CLASS
        }
        public TypeOfException type;
        public MoodAnalyserException(TypeOfException type,string message): base(message)
        {
            this.type = type;
        }
    }
    
}
