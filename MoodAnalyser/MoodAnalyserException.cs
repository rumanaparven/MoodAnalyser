using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserException: ApplicationException
    {
        public enum TypeOfException
        {
            NULL_ENTRY, EMPTYSTRING_ENTRY
        }
        public TypeOfException type;
        public MoodAnalyserException(TypeOfException type,string message): base(message)
        {
            this.type = type;
        }
    }
    
}
