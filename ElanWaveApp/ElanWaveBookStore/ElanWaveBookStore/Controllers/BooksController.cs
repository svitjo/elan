using ElanWaveBookStore.Models;
using ElanWaveBookStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElanWaveBookStore.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]

    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService bookService, ILogger<BooksController> logger)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public ActionResult<Book> GetAll()
        {
            IEnumerable<Book> books;
            try
            {
                books = _bookService.GetAll();
            } catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Unable to get books");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(books);
        }

        [HttpGet]
        [Route("{bookID}")]
        public async Task<ActionResult> GetAsync([FromRoute] Guid bookID)
        {
            Book book;
            try
            {
                book = await _bookService.GetAsync(bookID);
            } catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Unable to get book");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Book book)
        {
            Book createdBook;
            try
            {
                createdBook = await _bookService.CreateAsync(book);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Unable to create books");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(createdBook);
        }

        [HttpPut]
        [Route("{bookID}")]
        public async Task<ActionResult> Update([FromBody] Book book, [FromRoute] Guid bookID)
        {
            Book updateBook;
            Book updatedBook;
            try
            {
                updateBook = await _bookService.GetAsync(bookID);
                
            }catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Unable to find books");
                return StatusCode(StatusCodes.Status404NotFound);
            }

            try
            {
                updatedBook = await _bookService.Update(book);
            } catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Unable to update books");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(updatedBook);
        }

        [HttpDelete]
        [Route("delete/{bookID}")]
        public async Task<ActionResult> Delete([FromRoute] Guid bookID)
        {
            try
            {
                await _bookService.Delete(bookID);
            } catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Unable to delete book");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent();
        }
    }
}
