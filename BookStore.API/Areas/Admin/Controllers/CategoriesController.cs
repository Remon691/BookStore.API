using BookStore.API.DTO.Category;
using ECommerce528.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Areas.Admin.Controllers
{
    [Area(SD.ADMIN_AREA)]
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepository<Category> _categoryRepository;
        public CategoriesController( IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string? query, CancellationToken cancellationToken = default)
        {
            IEnumerable<Category> categories;

            if (!string.IsNullOrWhiteSpace(query))
            {
                query = query.Trim().ToLower();
                categories = await _categoryRepository.GetAsync(e => e.Name.ToLower().Contains(query), cancellationToken: cancellationToken);

            }
            else
            {
                categories = await _categoryRepository.GetAsync(cancellationToken: cancellationToken);
            }
            // ابقى ارجع للنقطه دى تانى 
            var categoryResponseDto = categories.Select(e => new CategoryResponseDto
            {
                Id = e.Id,
                Name = e.Name,
            }).ToList();
            return Ok(categoryResponseDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken = default)
        {
            Category? category = await _categoryRepository.GetOneAsync(e => e.Id == id, cancellationToken: cancellationToken);
            if (category == null)
            {
                return NotFound();
            }
            var categoryResponseDto = new CategoryResponseDto()
            {
                Id = category.Id,
                Name = category.Name,
            };
            return Ok(categoryResponseDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            CategoryCreateDto categoryCreateDto,
            CancellationToken cancellationToken = default)
        {
            var existingCategory = await _categoryRepository.GetOneAsync(
                e => e.Name == categoryCreateDto.Name.Trim(),
                cancellationToken: cancellationToken);

            if (existingCategory is not null)
                return BadRequest("Category already exists.");

            var category = new Category
            {
                Name = categoryCreateDto.Name.Trim()
            };

            await _categoryRepository.CreateAsync(category, cancellationToken);
            await _categoryRepository.CommitAsync(cancellationToken);

            return CreatedAtAction(
                nameof(GetById),
                new { id = category.Id },
                new CategoryResponseDto
                {
                    Id = category.Id,
                    Name = category.Name
                });
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CategoryUpdateDto categoryUpdateDto, CancellationToken cancellationToken = default)
        {
            var result = await _categoryRepository.GetOneAsync(e => e.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return NotFound();
            var existingCategory = await _categoryRepository.GetOneAsync(  e => e.Name.ToLower() == categoryUpdateDto.Name.Trim().ToLower()
            && e.Id != id, cancellationToken: cancellationToken);

            if (existingCategory is not null)
                return BadRequest("Category already exists.");
            result.Name = categoryUpdateDto.Name.Trim();
            _categoryRepository.Update(result);
            await _categoryRepository.CommitAsync(cancellationToken);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var result = await _categoryRepository.GetOneAsync(e => e.Id == id, cancellationToken: cancellationToken);

            if (result == null)
            {
                return NotFound();

            }
            _categoryRepository.Delete(result);
            await _categoryRepository.CommitAsync(cancellationToken);
            return NoContent();

        }

    }
}
