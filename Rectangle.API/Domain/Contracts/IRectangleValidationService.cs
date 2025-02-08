using Rectangle.API.Models;

namespace Rectangle.API.Domain.Contracts
{
    public interface IRectangleValidationService
    {
        Task<string> ValidateRectangleAsync(RectangleDTO rectangle);
    }
}
