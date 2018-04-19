using CALibrary.BusinessObject;
using CALibrary.BusinessObjects;
using CALibrary.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CALibrary.BusinessLogic
{
    public class FileParserManager:IFileParserManager
    {
        
        #region Private Variables
        ValidateInput _validateMgr;
        private string _format;
       // private string _delimiter;
      
        #endregion

        #region Constructor
       
        public FileParserManager()
        {
            _validateMgr = new ValidateInput();            
        }
        #endregion

        #region ValidateFieldFormat
        public bool ValidateFileFormat(string [] inputRequest)
        {
            _validateMgr.checkForValidInputFormat(inputRequest);
            _validateMgr.ValidateFileFormat(inputRequest[1]);
            AssignFormaterAndDelimiter(inputRequest[1]);
            return true;

        }

        public void checkForValidInputFormat(string[] inputRequest)
        {
            _validateMgr.checkForValidInputFormat(inputRequest);

        }

        #endregion



        #region Private functions
        private void AssignFormaterAndDelimiter(string formatType)
        {
            _format = formatType;


        }
       

        private IStreamHandler _streamReader;
        public IStreamHandler StreamReaderHandler
        {
            get
            {
                if (_streamReader == null)
                {
                    _streamReader = new StreamHandler();
                }
                return _streamReader;
            }
            set
            {
                _streamReader = value;
            }
        }

        private IFileSystemHandler _fileSystemHandler;
        public IFileSystemHandler FileSystemHandler
        {
            get
            {
                if (_fileSystemHandler == null)
                {
                    _fileSystemHandler = new FileSystemHandler();
                }
                return _fileSystemHandler;
            }
            set
            {
                _fileSystemHandler = value;
            }
        }

        private List<Person> GetPersons(string path, char delimiter)
        {
            var persons = new List<Person>();
            CheckForFile(path);
            ParseFile(path, delimiter, persons);
            return persons;
        }

        private void CheckForFile(string path)
        {
            if (IsSpecifiedFileExists(path))
            {
                throw new Exception("Specified file is not found.");
            }
        }

        private bool IsSpecifiedFileExists(string path)
        {
            return (!FileSystemHandler.FileExists(path));
        }

        private List<Person> ParseFile(string path, char delimiter, List<Person> persons)
        {
            //var persons = new List<Person>();

            using (StreamReaderHandler)
            {
                CheckForFile(path);
                StreamReaderHandler.InitializeReader(path);
                ReadLines(delimiter, persons);
            }

            return persons;
        }

        private void ReadLines(char delimiter, List<Person> persons)
        {
            string line;
            while ((line = StreamReaderHandler.ReadLine()) != null)
            {
                string[] parsedRecord = line.Split(delimiter);
                CheckArraySize(parsedRecord);
                Person person = GetPerson(parsedRecord);
                persons.Add(person);
            }
        }


        private void CheckArraySize(string[] parsedRecord)
        {
            if (IsParsedRecordArrayWrongSize(parsedRecord))
            {
                throw new Exception("Parsing of record failed. Parsed record array does not have five elements.");
            }
        }

        private bool IsParsedRecordArrayWrongSize(string[] parsedRecord)
        {
            return (parsedRecord.Length != 5);
        }

        private static Person GetPerson(string[] parsedRecord)
        {
            var person = new Person()
            {
                LastName = parsedRecord[0],
                FirstName = parsedRecord[1],
                Gender = parsedRecord[2],
                FavoriteColor = parsedRecord[3],
            };
            SetDateOfBirth(parsedRecord, person);

            return person;
        }

        private static void SetDateOfBirth(string[] strAryRecords, Person person)
        {
            DateTime result;
            bool success = DateTime.TryParse(strAryRecords[4], out result);
            if (success)
            {
                person.DateOfBirth = result;
            }
        }
        #endregion

        #region GetPersonList

        public List<Person> GetPersonList(string [] filePath)
        {
            List<Person> personsList = new List<Person>();
            KeyValuePair<string, char> delimiter = _validateMgr.GetDilimiter(filePath[1]);
            personsList = GetPersons(filePath[0], delimiter.Value);
            return personsList;

        }

        #endregion


        #region GetPerson
        public Person GetPerson(char delimeter, string record)
        {
            Person person;
            try
            {              

                string[] parsedRecord = record.Split(delimeter);
                CheckArraySize(parsedRecord);
                person = GetPerson(parsedRecord);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return person;
        }

        #endregion

    }
}
