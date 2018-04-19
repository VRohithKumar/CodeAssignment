using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CALibrary.BusinessLogic;
using CALibrary.BusinessObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CAUnitTestProject
{
    [TestClass]
    public class FileParseManagerUnitTest
    {
        private FileParserManager _fileParseManager;

        [TestInitialize]
        public void Initialize()
        {
            _fileParseManager = new FileParserManager();
        }

        [TestMethod]
        public void ValidateFileFormat()
        {
            //arrange
            string[] input = new string[] { "d:/abcd.txt", "comma" };

            //act
            bool actual = _fileParseManager.ValidateFileFormat(input);
            bool expected = true;

            //assert
            Assert.AreEqual(actual, expected);

        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ValidateInvalidFileFormat()
        {
            //arrange
            string[] input = new string[] { "d:/abcd.txt" };

            //act
            bool actual = _fileParseManager.ValidateFileFormat(input);
            bool expected = false;

            //assert
            Assert.AreEqual(actual, expected);

        }


        [TestMethod]
        public void ValidatePersonsListByFilePath()
        {
            //arrange
            string [] filePath = new string[] { "G:/Sample example of comma.txt", "comma" };

            //act

            List<Person> persons = _fileParseManager.GetPersonList(filePath);

            //assert
            int actual = persons.Count;
            int expected = 3;
            Assert.AreEqual(actual, expected);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ValidatePersonsListByInvalidFilePath()
        {
            //arrange
            string[] filePath = new string[] { "D:/Sample example of comma.txt", "comma" };

            //act
            List<Person> persons = _fileParseManager.GetPersonList(filePath);

            //assert
            int actual = persons.Count;
            int expected = 3;
            Assert.AreEqual(actual, expected);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ValidatePersonsListByInvalidFileFormat()
        {
            //arrange
            string[] filePath = new string[] { "D:/Sample example of comma.txt", "pipe" };

            //act
            List<Person> persons = _fileParseManager.GetPersonList(filePath);

            //assert
            int actual = persons.Count;
            int expected = 3;
            Assert.AreEqual(actual, expected);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ValidatePersonsListByInvalidFieldCount()
        {
            //arrange
            string[] filePath = new string[] { "G:/Sample example of comma with missing fields.txt", "comma" };

            //act
            List<Person> persons = _fileParseManager.GetPersonList(filePath);

            //assert
           Assert.Fail();
        }


    }
}
