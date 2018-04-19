using CALibrary.BusinessObject;
using CALibrary.BusinessObjects;
using CAWebAPI.Models;
using CAWebAPI.Services;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CAWebAPI.Controllers
{
    /// <summary>
    /// Used to manage File operations
    /// </summary>
    [RoutePrefix("api/records")]
    public class FileHadlerController : ApiController
    {
        #region Private Variables
        DataParser _dataParser;
        /// <summary>
        /// 
        /// </summary>
        public PersonDataCacheModel _personDataCacheModel = PersonDataCacheModel.GetInstance();
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public FileHadlerController()
        {
            _dataParser = new DataParser();
        }


        //// GET: api/student
        //[HttpGet]
        //[Route("Records")]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}



        ///  PUT : api/records/person
        /// <summary>
        /// Save Person model wizard data
        /// </summary>
        /// <param name="inputRequest">inputRequest object</param>
        /// <returns>Success Or Fail Message</returns>
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Bad request (INVALID_PARAM: When personRequest model data object is invalid)")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, Description = "Unauthorized")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Description = "Internal Server Error")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Response with a Success Message", Type = typeof(ApiResponse))]
       
        [HttpPost]
        [Route("person")]
        public HttpResponseMessage SavePersonRecord([FromBody] InputRecord inputRequest)
        {
            if (inputRequest == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "INVALID_PARAM: INUPUT REQUEST IS NULL");
            }
            if (inputRequest.Line == "")
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "INVALID_PARAM:INPUT LINE IS EMPTY");
            }
            if(!Enum.IsDefined(typeof(FormatEnum), inputRequest.Delimiter))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "INVALID_PARAM: DELIMITER");
            }

            Person person = new Person();
            person = _dataParser.GetPersonDetails(inputRequest.Delimiter, inputRequest.Line);
            _personDataCacheModel.Persons.Add(person);
            ApiResponse apiResponse = new ApiResponse();         
            apiResponse.MessageText = "Success";
            return Request.CreateResponse(HttpStatusCode.OK, apiResponse);
        }

       
        #region GetRecordsSortedByGender
        //  GET: api/records/sortby/gender/person
        /// <summary>
        /// Get Person details
        /// </summary>
        /// <param name="sortby">sortby</param>
        /// <returns>List of persons by specified sort order</returns>
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Bad request(INVALID_PARAM: when sortby is invalid )")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Not found(NOT_FOUND: Unable to return person list becasue of no records found)")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, Description = "Unauthorized")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Description = "Internal Server Error")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "List of Dashboard budgets", Type = typeof(ApiResponse<IList<Person>>))]
        
        [HttpGet]
        [Route("sortby/{sortby}/person")]
        public HttpResponseMessage GetDashboardBudgets(string sortby)
        {
            if (string.IsNullOrEmpty(sortby))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "INVALID_PARAM SORT BY");
            }
            if(!Enum.IsDefined(typeof(SortList), sortby))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "INVALID_PARAM SORT BY");
            }

            
            IList<Person> unsortedList = _personDataCacheModel.Persons;
            unsortedList = _dataParser.GetPersonListBySortOption(unsortedList, sortby);            

            if (unsortedList == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NOT_FOUND");
            }

            

            ApiResponse<IList<Person>> result = new ApiResponse<IList<Person>>();
           
            result.Records = unsortedList;
            result.MessageId = 200;
            result.MessageText = "Success";
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        #endregion
    }
}
