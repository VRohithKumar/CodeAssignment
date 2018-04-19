using CALibrary.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALibrary.BusinessLogic
{
    /// <summary>
    /// Provides the interface for FileParser Manager
    /// </summary>
    public interface IFileParserManager
    {
        /// <summary>
        /// Return true for valid file formats(comma, pipe , space) and false for invalid formats
        /// <param name="formatType">String formatType.</param>
        /// </summary>
        bool ValidateFileFormat(string [] formatType);

        /// <summary>
        /// Return list of records by parsing file based on file path
        /// <param name="filePath">filePath</param>
        /// </summary>
        List<Person> GetPersonList(string [] filePath);

        ///// <summary>
        ///// Return true if all valid supplied fields(LastName, FirstName, Gender, FavoriteColor, DateOfBirth) 
        ///// <param name="filePath">filePath</param>
        ///// </summary>
        //bool ValidatePersonList(List<Person> person);
    }
}
