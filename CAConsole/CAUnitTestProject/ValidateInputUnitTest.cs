using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CALibrary.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CAUnitTestProject
{
    [TestClass]
   public class ValidateInputUnitTest
    {
        private ValidateInput _validateInput ;
        [TestInitialize]
        public void Initialize()
        {
            _validateInput = new ValidateInput();

        }

        [TestMethod]
        public void ValidateFileFormatForCommaFormat()
        {
            //arrange
            string format = "comma";
            string wrongFormat = "noformat";


            //act
            _validateInput.ValidateFileFormat(format);

            //assert
            Assert.AreEqual("comma", format);
            Assert.AreNotEqual(format, wrongFormat);
        }

        [TestMethod]
        public void ValidateFileFormatForPipeFormat()
        {
            //arrange
            string format = "pipe";
            string wrongFormat = "noformat";


            //act
            _validateInput.ValidateFileFormat(format);

            //assert
            Assert.AreEqual("pipe", format);
            Assert.AreNotEqual(format, wrongFormat);
        }

        [TestMethod]
        public void ValidateFileFormatForSpaceFormat()
        {
            //arrange
            string format = "space";
            string wrongFormat = "noformat";


            //act
            _validateInput.ValidateFileFormat(format);

            //assert
            Assert.AreEqual("space", format);
            Assert.AreNotEqual(format, wrongFormat);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ValidateFileFormatForException()
        {
            //arrange
            string expected = "comma";
            string actual = "noformat";


            //act
            _validateInput.ValidateFileFormat(actual);

            //assert
           // Assert.AreEqual("comma", format);
            Assert.AreNotEqual(expected, actual);
        }


        [TestMethod]
        public void ValidateInputTypeHasTwoRecords()
        {
            //arrange
            string[] input = new string[] { "d:/abcd.txt", "comma" };

            //act
            _validateInput.checkForValidInputFormat(input);
            int expected = input.Length;

            //assert
            Assert.AreEqual(expected, input.Length);

        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ValidateInputTypesWhichAreNotEqualToTwo()
        {
            //arrange
            string[] input = new string[] { "d:/abcd.txt" };

            //act
            _validateInput.checkForValidInputFormat(input);
            int actual = input.Length;
            int expected = 2;

            //assert
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void getDelimiterBasedOnFileType()
        {

            //arrange
            //Dictionary<string, char> delimiters = getDelimiterList();
            Dictionary<string, char> delimiters = new Dictionary<string, char>();
            delimiters.Add("comma", ',');
            string fileType = "comma";

            //act
            KeyValuePair<string, char> actualResult = _validateInput.GetDilimiter(fileType);

            char actual = actualResult.Value;
            char expected;
            delimiters.TryGetValue("comma", out expected);

            //assert
            Assert.AreEqual(actual, expected);
        }

        public Dictionary<string, char> getDelimiterList()
        {
            Dictionary<string, char> delimiters = new Dictionary<string, char>();
            delimiters.Add("comma", ',');
            delimiters.Add("pipe", '|');
            delimiters.Add("space", ' ');
            return delimiters;
        }
    }
}
