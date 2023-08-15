using BookApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            try
            {
                var booksDb = StaticDb.Books;
               
                return Ok(booksDb);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("index")]
        public ActionResult<Book> GetByQueryString(int? index)
        {
            try
            {
                if (index == null)
                {
                    return BadRequest("Index is a required paramter.");
                }
                if (index < 0)
                {
                    return BadRequest("Index can not be a negative value.");
                }
                if (index >= StaticDb.Books.Count)
                {
                    return NotFound($"There is no resource with an index of {index}");
                }

                return Ok(StaticDb.Books[index.Value]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
            }
        }
        [HttpGet("multipleQueryParams")]
        public ActionResult<List<Book>> FilterBooksByMultipleQueryParams(string? author, string? title)
        {
            try
            {
                if (string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
                {
                    return BadRequest("Both paramaters are required!");
                }
                var booksDb = StaticDb.Books;

                return Ok(StaticDb.Books.Where(x => x.Author.ToLower() == author.ToLower() && x.Title.ToLower() == title.ToLower()).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
            }
        }
        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            try
            {
                if (string.IsNullOrEmpty(book.Author))
                {
                    return BadRequest("Insert author name.");
                }
                
                if (string.IsNullOrEmpty(book.Title))
                {
                    return BadRequest("Insert some priority");
                }

                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
            }
        }
        [HttpPost("getBooksTitles")]
        public ActionResult<List<string>> GetTitles([FromBody] List<Book> book) 
        {
            try
            {
                if (book == null)
                {
                    return BadRequest("List of book titles is required!");

                }
                var bookTitles = book.Select(b => b.Title.ToList());
                return Ok(bookTitles);
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
            }
        }
    }
}
