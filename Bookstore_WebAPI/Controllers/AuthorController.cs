using AutoMapper;
using Bookstore_WebAPI.DTO;
using Bookstore_WebAPI.Interfaces;
using Bookstore_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Author>))]
        public IActionResult GetAuthors()
        {
            var authors = _mapper.Map<List<AuthorDTO>>(_authorRepository.GetAuthors());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(authors);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Author))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthor(int id)
        {
            //check if this author even exists
            if (!_authorRepository.HasAuthor(id))
                return NotFound();
            var author = _mapper.Map<AuthorDTO>(_authorRepository.GetAuthor(id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(author);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAuthor([FromBody] AuthorDTO authorCreate)
        {
            if (authorCreate == null)
                return BadRequest(ModelState);
            var author = _authorRepository.GetAuthors()
                .Where(a => a.FirstName.Trim().ToUpper() == authorCreate.FirstName.TrimEnd().ToUpper() && a.LastName.Trim().ToUpper() == authorCreate.LastName.TrimEnd().ToUpper())
                .FirstOrDefault();
            if (author != null)
            {
                ModelState.AddModelError("", "Author already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var authorMap = _mapper.Map<Author>(authorCreate);
            if (!_authorRepository.CreateAuthor(authorMap))
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
        public IActionResult UpdateAuthor(int id, [FromBody] AuthorDTO updatedAuthor)
        {
            if (updatedAuthor == null)
                return BadRequest();

            if (id != updatedAuthor.Id)
                return BadRequest();

            if (!_authorRepository.HasAuthor(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var authorMap = _mapper.Map<Author>(updatedAuthor);
            if (!_authorRepository.UpdateAuthor(authorMap))
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
        public IActionResult DeleteAuthor(int id)
        {
            if (!_authorRepository.HasAuthor(id))
                return NotFound();

            var authorToDelete = _authorRepository.GetAuthor(id);
            
            if (!ModelState.IsValid)
                return BadRequest();
            if (!_authorRepository.DeleteAuthor(authorToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
