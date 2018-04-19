using CALibrary.BusinessLogic;
using CALibrary.BusinessObject;
using CAWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAWebAPI.Services
{

    /// <summary>
    /// Data parser class which does operations with data
    /// </summary>
    public class DataParser
    {

        #region Private Variables
        ValidateInput _validateMgr;
        FileParserManager _fileParserMgr;
        ISortServiceManager _sortServiceManager;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public DataParser()
        {
            _validateMgr = new ValidateInput();
            _fileParserMgr = new FileParserManager();
        }

        /// <summary>
        /// Get person details 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="recordLine"></param>
        /// <returns></returns>
        public Person GetPersonDetails(string format, string recordLine)
        {
            Person person = new Person();
            KeyValuePair<string, char> delimiter = _validateMgr.GetDilimiter(format);
            person = _fileParserMgr.GetPerson(delimiter.Value, recordLine);
            return person;
        }
        /// <summary>
        /// get person by sort order
        /// </summary>
        /// <param name="person"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public IList<Person> GetPersonListBySortOption(IList<Person> person, string sortBy)
        {
            _sortServiceManager = new SortServiceManager();
            IList<Person> persons = new List<Person>();
            persons = GetPersonListWithSorting(person, sortBy);
            return persons;

        }
        /// <summary>
        /// private method gets person by sort order
        /// </summary>
        /// <param name="person"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        private IList<Person> GetPersonListWithSorting(IList<Person> person, string sortBy)
        {
            if (Enum.TryParse(sortBy, out SortList result))
            {
                switch (result)
                {
                    case SortList.name:
                        person = _sortServiceManager.SortByLastNameDescending(person);
                        break;
                    case SortList.gender:
                        person = _sortServiceManager.SortByGenderAndLastNameAscending(person);
                        break;
                    case SortList.birthdate:
                        person = _sortServiceManager.SortByBirthDateAscending(person);
                        break;

                }
            }
            return person;

        }




    }
}