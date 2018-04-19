using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CALibrary.BusinessObjects;


namespace CALibrary.BusinessLogic
{
   public class ValidateInput
    {
              
        public void ValidateFileFormat(string format)
        {
            if (!Enum.IsDefined(typeof(FormatEnum), format))
            {
                throw new Exception("Please enter valid format type (comma, pipe and space).");
            };
        }

        public Dictionary<string, char> GetDelimiters()
        {
            Dictionary<string, char> delimiters = new Dictionary<string, char>();
            delimiters.Add("comma", ',');
            delimiters.Add("pipe", '|');
            delimiters.Add("space", ' ');
            return delimiters;
        }

        public KeyValuePair<string, char> GetDilimiter(string formatType)
        {
             Dictionary<string, char> _delimiters= GetDelimiters();
            return (from d in _delimiters
                    where d.Key == formatType
                    select d).FirstOrDefault();
        }

        public void checkForValidInputFormat(string [] input)
        {
            if (input.Length != 2)
            {
                throw new Exception("Please check the input given. " +
                    "It should have two input fields with file name , type");
            }            
        }



    }
}
