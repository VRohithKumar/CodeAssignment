using System;
using System.Collections.Generic;
using CALibrary.BusinessLogic;
using CALibrary.BusinessObject;

namespace CAConsole
{
    class Program
    {
        private static IFileParserManager _fileParserService;
        private static ISortServiceManager _sortDerviceManager;
        static void Main(string[] args)
        {
            try
            {
                InitializeFileParseService();
                ParseFile();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("press any key to exit..");
                Console.ReadKey();
            }           
        }

        private static void InitializeFileParseService()
        {
            _fileParserService = new FileParserManager();
            _sortDerviceManager = new SortServiceManager();

        }

        private static void ParseFile()
        {
            Console.WriteLine("Enter full path and type of delimiters (commas, pipes and spaces)"
                                + ": Ex: d:/abc.txt,commas");
            string[] input = Console.ReadLine().Split(',');
            try
            {
                if (_fileParserService.ValidateFileFormat(input))
                {
                    IList<Person> unsortedList = _fileParserService.GetPersonList(input);
                    ProcessFile(unsortedList);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("press any key to exit..");
                Console.ReadKey();
            }

        }


        private static void ProcessFile(IList<Person> unsortedList)
        {
            SortByGenderAndLastNameAscending(unsortedList);
            SortByBirthDateAscending(unsortedList);
            SortByLastNameDescending(unsortedList);
        }

        private static void SortByLastNameDescending(IList<Person> unsortedList)
        {
            IList<Person> sortedBylastName = _sortDerviceManager.SortByLastNameDescending(unsortedList);
            Console.WriteLine(" ");
            Console.WriteLine("Sorted by last name by descending order.");
            PrintList(sortedBylastName);
        }

        private static void SortByBirthDateAscending(IList<Person> unsortedList)
        {
            IList<Person> sortedByBirthdate = _sortDerviceManager.SortByBirthDateAscending(unsortedList);
            Console.WriteLine(" ");
            Console.WriteLine("Sorted by date of birth by ascending order.");
            PrintList(sortedByBirthdate);
        }

        private static void SortByGenderAndLastNameAscending(IList<Person> unsortedList)
        {
            IList<Person> sortedByGender = _sortDerviceManager.SortByGenderAndLastNameAscending(unsortedList);
            Console.WriteLine(" ");
            Console.WriteLine("Sorted by gender &  by last name in ascending order.");
            PrintList(sortedByGender);
        }

        private static void PrintList(IList<Person> persons)
        {
            foreach (var item in persons)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}",
                    item.LastName,
                    item.FirstName,
                    item.Gender,
                    item.FavoriteColor,
                    item.DateOfBirth.ToString("d"));
            }
        }
    }
}
