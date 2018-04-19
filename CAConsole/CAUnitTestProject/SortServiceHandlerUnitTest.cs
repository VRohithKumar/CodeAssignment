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
   public  class SortServiceHandlerUnitTest
    {
        private ISortServiceManager _sortServiceManager;

        [TestInitialize]
        public void Initialize()
        {
            _sortServiceManager = new SortServiceManager();
        }

        [TestMethod]
        public void SortByLastNameAndGenderAssending()
        {
            //arrange
            List<Person> unsortedList = GetUnsortedPersonList();

            //act
            IList<Person> sortedList = _sortServiceManager.SortByGenderAndLastNameAscending(unsortedList);
            var first = sortedList.FirstOrDefault();
            var last = sortedList.LastOrDefault();

            //assert
            Assert.AreEqual("Brite", first.LastName);
            Assert.AreEqual("Watson", last.LastName);
        }

        [TestMethod]
        public void SortByBirthDateAscending()
        {
            //arrange
            List<Person> unsortedList = GetUnsortedPersonList();

            //act
            IList<Person> sortedList = _sortServiceManager.SortByBirthDateAscending(unsortedList);
            var first = sortedList.FirstOrDefault();
            var last = sortedList.LastOrDefault();

            //assert
            Assert.AreEqual("Vin", first.LastName);
            Assert.AreEqual("Arnold", last.LastName);

        }

        [TestMethod]
        public void SortByLastNameDescending()
        {
            //arrange
            List<Person> unsortedList = GetUnsortedPersonList();

            //act
            IList<Person> sortedList = _sortServiceManager.SortByLastNameDescending(unsortedList);
            var first = sortedList.FirstOrDefault();
            var last = sortedList.LastOrDefault();

            //assert
            Assert.AreEqual("Watson",first.LastName);
            Assert.AreEqual("Arnold", last.LastName);
        }


        private static List<Person> GetUnsortedPersonList()
        {
            var person1 = new Person() { LastName = "Vin", FirstName = "Vineet", Gender = "Male", FavoriteColor = "Yellow", DateOfBirth = DateTime.Parse("4/10/1960") };
            var person2 = new Person() { LastName = "Brite", FirstName = "Christine", Gender = "Female", FavoriteColor = "Turquoise", DateOfBirth = DateTime.Parse("11/20/1980") };
            var person3 = new Person() { LastName = "Reddy", FirstName = "Prateek", Gender = "Female", FavoriteColor = "Goldenrod", DateOfBirth = DateTime.Parse("12/27/1971") };
            var person4 = new Person() { LastName = "best", FirstName = "Younion", Gender = "Male", FavoriteColor = "Violet", DateOfBirth = DateTime.Parse("3/12/1975") };
            var person5 = new Person() { LastName = "Arnold", FirstName = "Prince", Gender = "Male", FavoriteColor = "Goldenrod", DateOfBirth = DateTime.Parse("3/23/1981") };
            var person6 = new Person() { LastName = "Watson", FirstName = "Shaine", Gender = "Male", FavoriteColor = "Teal", DateOfBirth = DateTime.Parse("5/25/1977") };

            var persons = new List<Person>() { person1, person2, person3, person4, person5, person6 };
            return persons;
        }

    }
}
