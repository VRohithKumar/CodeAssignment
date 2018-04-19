using CALibrary.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAWebAPI.Models
{
    /// <summary>
    /// Used to Get PersonDataCacheModel
    /// </summary>
    public class PersonDataCacheModel
    {
        /// <summary>
        /// person list
        /// </summary>
        public IList<Person> Persons { get; set; }

        private PersonDataCacheModel()
        {
            Persons = new List<Person>();
        }
      
        private static volatile PersonDataCacheModel _instance = null;
        /// <summary>
        /// 
        /// </summary>
        public static PersonDataCacheModel GetInstance()
        {
            if (_instance == null)
            {
                lock (typeof(PersonDataCacheModel))
                {
                    _instance = new PersonDataCacheModel();
                }
            }
            return _instance;
        }
    }
}
