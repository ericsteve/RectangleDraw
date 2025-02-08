using Rectangle.API.Domain.Contracts;
using Rectangle.API.Models;

namespace Rectangle.API.Services
{
    public class RectangleValidationService : IRectangleValidationService
    {
        public async Task<string> ValidateRectangleAsync(RectangleDTO rectangle)
        {
            await Task.Delay(10000);

            if (rectangle.Width > rectangle.Height)
            {
                return "Width cannot exceed height.";
            }

            return string.Empty;
        }
    }
}
