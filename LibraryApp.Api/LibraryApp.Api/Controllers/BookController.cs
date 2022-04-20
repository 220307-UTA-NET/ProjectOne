using System.Data.SqlClient;
using LibraryApp.BusinessLogias;
using LibraryApp.DataLogias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //Fields
        private readonly IRepository _repository;
        private readonly ILogger<BookController> _logger;

        //Constructors
        public BookController(IRepository repository, ILogger<BookController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        //Methods
        [HttpGet("/allbooks")]
        public async Task<ActionResult<IEnumerable<Book>>> LookUpAllBooksAsync()
        {
            IEnumerable<Book> books;
            try
            {
                books = await _repository.GetAllBooks();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL communication error.");
                return StatusCode(500);
            }
            return books.ToList();
        }
        //[HttpGet("/abook")]
        //public async Task<int>
    }
}
