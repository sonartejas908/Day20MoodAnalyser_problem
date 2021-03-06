using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Day20_MoodAnalyserProblem
{
    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyser(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            
            if(result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch(ArgumentNullException)
                {
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NULL_MESSAGE, "Message should not be null");
                }
              

            }

            else if (className != "Day20_MoodAnalyserProblem.MoodAnalyzer")
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_CLASS, "Class not found");
            }
            else if (constructorName != "MoodAnalyzer")
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_METHOD, "No such Method");
            }
            else 
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_METHOD, "No such Method");
            }
        }
    }
}
