using AutoMapper;
using Bookstore_WebAPI.DTO;
using Bookstore_WebAPI.Interfaces;
using Bookstore_WebAPI.Models;
using Bookstore_WebAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly ITranslatorRepository _translatorRepository;
        private readonly IMapper _mapper;
        public BookController(IBookRepository bookRepository, IItemRepository itemRepository, IPublisherRepository publisherRepository, ITranslatorRepository translatorRepository, IGenreRepository genreRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _itemRepository = itemRepository;
            _publisherRepository = publisherRepository;
            _translatorRepository = translatorRepository;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        public IActionResult GetBooks()
        {
            var books = _mapper.Map<List<BookDTO>>(_bookRepository.GetBooks());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(books);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Book))]
        [ProducesResponseType(400)]
        public IActionResult GetBook(int id)
        {
            if (!_bookRepository.HasBook(id))
                return NotFound();
            var book = _mapper.Map<BookDTO>(_bookRepository.GetBook(id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(book);
        }
        [HttpGet("genre/{genreId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        [ProducesResponseType(400)]
        public IActionResult GetBooksByGenre(int genreId)
        {
            if (!_bookRepository.HasBook(genreId))
                return NotFound();
            var books = _mapper.Map<List<BookDTO>>(_bookRepository.GetBooksByGenre(genreId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(books);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateBook([FromBody] BookDTO bookCreate)
        {
            if (bookCreate == null)
                return BadRequest(ModelState);
            var bookId = _itemRepository.GetItems()
                .Where(i => i.Id == bookCreate.ItemId)
                .FirstOrDefault();
            if (bookId == null)
            {
                ModelState.AddModelError("", "Item with given id doesn't exist");
                return StatusCode(422, ModelState);
            }

            var publisherId = _publisherRepository.GetPublishers()
                .Where(p => p.Id == bookCreate.PublisherId)
                .FirstOrDefault();
            if (publisherId == null)
            {
                ModelState.AddModelError("", "Publisher with given id doesn't exist");
                return StatusCode(422, ModelState);
            }

            var genreId = _genreRepository.GetGenres()
                .Where(g => g.Id == bookCreate.GenreId)
                .FirstOrDefault();
            if (genreId == null)
            {
                ModelState.AddModelError("", "Genre with given id doesn't exist");
                return StatusCode(422, ModelState);
            }

            var translatorId = _translatorRepository.GetTranslators()
                .Where(t => t.Id == bookCreate.TranslatorId)
                .FirstOrDefault();
            if (translatorId == null)
            {
                ModelState.AddModelError("", "Translator with given id doesn't exist");
                return StatusCode(422, ModelState);
            }

            var book = _bookRepository.GetBooks()
                .Where(b => b.ItemId == bookCreate.ItemId)
                .FirstOrDefault();
            if (book != null)
            {
                ModelState.AddModelError("", "Book with given item id doesn't exist");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bookMap = _mapper.Map<Book>(bookCreate);
            if (!_bookRepository.CreateBook(bookMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateBook(int bookId, [FromBody] BookDTO updatedBook)
        {
            if (updatedBook == null)
                return BadRequest();

            if (bookId != updatedBook.ItemId)
                return BadRequest();

            if (!_bookRepository.HasBook(bookId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var bookMap = _mapper.Map<Book>(updatedBook);
            if (!_bookRepository.UpdateBook(bookMap))
            {
                ModelState.AddModelError("", "Something went wrong updating");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteBook(int bookId)
        {
            if (!_bookRepository.HasBook(bookId))
                return NotFound();

            var bookToDelete = _bookRepository.GetBook(bookId);

            if (!ModelState.IsValid)
                return BadRequest();
            if (!_bookRepository.DeleteBook(bookToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
