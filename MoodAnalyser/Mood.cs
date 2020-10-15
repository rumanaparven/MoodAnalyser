using System;


namespace MoodAnalyser
{
    public class Mood
    {
        private string message;
        public Mood()
        {

        }
        public Mood(string message)
        {
            this.message = message;
        }
        public string AnalayseMood()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                    throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.EMPTYSTRING_ENTRY,"string should not be empty");
                else if (this.message.Contains("HAPPY"))
                    return "HAPPY";
                else
                    return "SAD";
            }
            catch(NullReferenceException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.TypeOfException.NULL_ENTRY, "string should not be null");
            }
        }
    }
}
