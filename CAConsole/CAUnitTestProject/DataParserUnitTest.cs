using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CALibrary.BusinessLogic;
using CALibrary.BusinessObject;
using CAWebAPI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CAUnitTestProject
{
    [TestClass]
   public class DataParserUnitTest
    {
        private DataParser _dataParser;
       // private ValidateInput _validateMgr;

        [TestInitialize]
        public void Initialize()
        {
            _dataParser = new DataParser();
            //_validateMgr = new ValidateInput();
        }

       
        [TestMethod]
        public void GetPersonDetailsWillGEtPersonDetails()
        {
            //arrange
            Person person = new Person()
            {
                LastName = "Kert",
                FirstName = "Jhonson",
                Gender = "Male",
                FavoriteColor = "White",
                DateOfBirth = DateTime.Parse("5/25/1977")
            };
            string format = "comma";
            string recordLine = "Kert, Jhonson, Male, White, 5/25/1977";
            Person actualObj = new Person();


            //act
            actualObj = _dataParser.GetPersonDetails(format, recordLine);

            string actual = actualObj.FirstName;
            string expected = person.FirstName;
            //assert

            Assert.AreEqual("Jhonson", expected);

        }

        [TestMethod]
        public void getsortListBySortType()
        {
            //arrange
            List<Person> person = getPersonList();
            string sortBy = "name";

            //act
            IList<Person> actualData = new List<Person>();
            actualData= _dataParser.GetPersonListBySortOption(person, sortBy);
            var firstRecord = actualData.FirstOrDefault();
            var lastRecord = actualData.LastOrDefault();

            //assert
            Assert.AreEqual("Watson", firstRecord.LastName);
            Assert.AreEqual("Arnold", lastRecord.LastName);
        }

        [TestMethod]
        public void getsortListBySortByGender()
        {
            //arrange
            List<Person> person = getPersonList();
            string sortBy = "gender";

            //act
            IList<Person> actualData = new List<Person>();
            actualData = _dataParser.GetPersonListBySortOption(person, sortBy);
            var firstRecord = actualData.FirstOrDefault();
            var lastRecord = actualData.LastOrDefault();

            //assert
            Assert.AreEqual("Watson", firstRecord.LastName);
            Assert.AreEqual("Kert", lastRecord.LastName);
        }

        [TestMethod]
        public void getsortListBySortByBirthDate()
        {
            //arrange
            List<Person> person = getPersonList();
            string sortBy = "birthdate";

            //act
            IList<Person> actualData = new List<Person>();
            actualData = _dataParser.GetPersonListBySortOption(person, sortBy);
            var firstRecord = actualData.FirstOrDefault();
            var lastRecord = actualData.LastOrDefault();

            //assert
            Assert.AreEqual("Kert", firstRecord.LastName);
            Assert.AreEqual("Watson", lastRecord.LastName);
        }


        private static List<Person> getPersonList()
        {
            List<Person> person = new List<Person>();
            Person person1 = new Person()
            {
                LastName = "Kert",
                FirstName = "Jhonson",
                Gender = "Male",
                FavoriteColor = "White",
                DateOfBirth = DateTime.Parse("5/25/1977")
            };
            Person person2 = new Person()
            {
                LastName = "Arnold",
                FirstName = "Jhonson",
                Gender = "Male",
                FavoriteColor = "White",
                DateOfBirth = DateTime.Parse("5/25/1980")
            };
            Person person3 = new Person()
            {
                LastName = "Watson",
                FirstName = "Jasmin",
                Gender = "female",
                FavoriteColor = "White",
                DateOfBirth = DateTime.Parse("5/25/1990")
            };
            var persons = new List<Person>() { person1, person2 , person3};
            return persons;


        }

    }
}
