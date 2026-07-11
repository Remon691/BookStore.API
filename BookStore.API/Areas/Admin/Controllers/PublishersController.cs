using BookStore.API.DTO.Category;
using BookStore.API.DTO.Publisher;
using ECommerce528.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Areas.Admin.Controllers
{
    [Area(SD.ADMIN_AREA)]
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IRepository<Publisher> _publisherRepository;
        public PublishersController( IRepository<Publisher> publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string? query, CancellationToken cancellationToken = default)
        {
            IEnumerable<Publisher> publishers;

            if (!string.IsNullOrWhiteSpace(query))
            {
                query = query.Trim().ToLower();
                publishers = await _publisherRepository.GetAsync(e => e.Name.ToLower().Contains(query), cancellationToken: cancellationToken);

            }
            else
            {
                publishers = await _publisherRepository.GetAsync(cancellationToken: cancellationToken);
            }
            // ابقى ارجع للنقطه دى تانى 
            var publisherResponseDto = publishers.Select(e => new PublisherResponseDto
            {
                Id = e.Id,
                Name = e.Name,
                 
            }).ToList();
            return Ok(publisherResponseDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken = default)
        {
            Publisher? publisher = await _publisherRepository.GetOneAsync(e => e.Id == id, cancellationToken: cancellationToken);
            if (publisher == null)
            {
                return NotFound();
            }
            var publisherResponseDto = new PublisherResponseDto()
            {
                Id = publisher.Id,
                Name = publisher.Name,
            };
            return Ok(publisherResponseDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            PublisherCreateDto publisherCreateDto,
            CancellationToken cancellationToken = default)
        {
            var existingPublisher = await _publisherRepository.GetOneAsync(
                e => e.Name == publisherCreateDto.Name.Trim(),
                cancellationToken: cancellationToken);

            if (existingPublisher is not null)
                return BadRequest("Publisher already exists.");

            var publisher = new Publisher
            {
                Name = publisherCreateDto.Name.Trim()
                
            };

            await _publisherRepository.CreateAsync(publisher, cancellationToken);
            await _publisherRepository.CommitAsync(cancellationToken);

            return CreatedAtAction(
                nameof(GetById),
                new { id = publisher.Id },
                new PublisherResponseDto
                {
                    Id = publisher.Id,
                    Name = publisher.Name

                });
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, PublisherUpdateDto publisherUpdateDto, CancellationToken cancellationToken = default)
        {
            var result = await _publisherRepository.GetOneAsync(e => e.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return NotFound();
            var existingPublisher = await _publisherRepository.GetOneAsync(
       e => e.Name.ToLower() == publisherUpdateDto.Name.Trim().ToLower()
            && e.Id != id,
       cancellationToken: cancellationToken);

            if (existingPublisher is not null)
                return BadRequest("Publisher already exists.");
            result.Name = publisherUpdateDto.Name.Trim();

            _publisherRepository.Update(result);
            await _publisherRepository.CommitAsync(cancellationToken);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var result = await _publisherRepository.GetOneAsync(e => e.Id == id, cancellationToken: cancellationToken);

            if (result == null)
            {
                return NotFound();

            }
            _publisherRepository.Delete(result);
            await _publisherRepository.CommitAsync(cancellationToken);
            return NoContent();

        }

    }
}
