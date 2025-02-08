using Microsoft.AspNetCore.Mvc;
using Rectangle.API.Domain.Contracts;
using Rectangle.API.Models;

namespace Rectangle.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RectangleController : Controller
    {
        private readonly IRectangleValidationService rectangleValidationService;
        private readonly IRectangleService rectangleService;

        public RectangleController(IRectangleValidationService rectangleValidationService,
            IRectangleService rectangleService)
        {
            this.rectangleValidationService = rectangleValidationService;
            this.rectangleService = rectangleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRectangle(CancellationToken cancellationToken)
        {
            var rectangle = await rectangleService.GetRectangleAsync(cancellationToken);
            return Ok(rectangle);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRectangle([FromBody] RectangleDTO dto, CancellationToken cancellationToken)
        {
            var validationResult = await rectangleValidationService.ValidateRectangleAsync(dto);
            if (!String.IsNullOrEmpty(validationResult))
            {
                return BadRequest(validationResult);
            }

            await rectangleService.UpdateRectangleAsync(dto, cancellationToken);
            return Ok();
        }
    }
}
