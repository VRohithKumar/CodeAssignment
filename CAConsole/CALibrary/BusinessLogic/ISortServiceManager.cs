using CALibrary.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALibrary.BusinessLogic
{
    public interface ISortServiceManager
    {

        IList<Person> SortByGenderAndLastNameAscending(IList<Person> persons);
        IList<Person> SortByBirthDateAscending(IList<Person> persons);
        IList<Person> SortByLastNameDescending(IList<Person> persons);
    }
}
