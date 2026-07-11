using BookStore.API.DTO.Author;
using ECommerce528.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Areas.Admin.Controllers
{
    [Area(SD.ADMIN_AREA)]
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IRepository<Author> _authorRepository;
        public AuthorsController(UserManager<ApplicationUser> userManager, IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string? query, CancellationToken cancellationToken = default)
        {
            IEnumerable<Author> authors;

            if (!string.IsNullOrWhiteSpace(query))
            {
                query = query.Trim().ToLower();
                authors = await _authorRepository.GetAsync(e => e.Name.ToLower().Contains(query), cancellationToken: cancellationToken);

            }
            else
            {
                authors = await _authorRepository.GetAsync(cancellationToken: cancellationToken);
            }
            // ابقى ارجع للنقطه دى تانى 
            var authorResponseDto = authors.Select(e => new AuthorResponseDto
            {
                Id = e.Id,
                Name = e.Name,
                Bio=e.Bio,
            }).ToList();
            return Ok(authorResponseDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken = default)
        {
            Author? author = await _authorRepository.GetOneAsync(e => e.Id == id, cancellationToken: cancellationToken);
            if (author == null)
            {
                return NotFound();
            }
            var authorResponseDto = new AuthorResponseDto()
            {
                Id = author.Id,
                Name = author.Name,
                Bio = author.Bio,
            };
            return Ok(authorResponseDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(AuthorCreateDto authorCreateDto, CancellationToken cancellationToken = default)
        {
            var existingAuthor = await _authorRepository.GetOneAsync(e => e.Name == authorCreateDto.Name.Trim(), cancellationToken: cancellationToken);

            if (existingAuthor is not null)
                return BadRequest("Author already exists.");

            var author = new Author
            {
                Name = authorCreateDto.Name.Trim(),
                Bio = authorCreateDto.Bio?.Trim(),
            };

            await _authorRepository.CreateAsync(author, cancellationToken);
            await _authorRepository.CommitAsync(cancellationToken);

            return CreatedAtAction(
                nameof(GetById),
                new { id = author.Id },
                new AuthorResponseDto
                {
                    Id = author.Id,
                    Name = author.Name,
                    Bio = author.Bio,
                });
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, AuthorUpdateDto authorUpdateDto, CancellationToken cancellationToken = default)
        {
            var result = await _authorRepository.GetOneAsync(e => e.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return NotFound();
            var existingAuthor = await _authorRepository.GetOneAsync( e => e.Name.ToLower() == authorUpdateDto.Name.Trim().ToLower() && e.Id != id, cancellationToken: cancellationToken);

            if (existingAuthor is not null)
                return BadRequest("Author already exists.");
            result.Name = authorUpdateDto.Name.Trim();
            result.Bio = authorUpdateDto.Bio?.Trim();
            _authorRepository.Update(result);
            await _authorRepository.CommitAsync(cancellationToken);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var result = await _authorRepository.GetOneAsync(e => e.Id == id, cancellationToken: cancellationToken);

            if (result == null)
            {
                return NotFound();

            }
            _authorRepository.Delete(result);
            await _authorRepository.CommitAsync(cancellationToken);
            return NoContent();

        }

    }
}
