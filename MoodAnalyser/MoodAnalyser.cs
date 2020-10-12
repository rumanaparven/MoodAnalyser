using System;
using System.Collections.Generic;
using System.Text;

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
            if (this.message.Contains("SAD"))
                return "SAD";
            else if (this.message.Contains("HAPPY"))
                return "SAD";
            else
                return "HAPPY";
        }
    }
}
