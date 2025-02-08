using Rectangle.API.Models;

namespace Rectangle.API.Domain.Contracts
{
    public interface IRectangleService
    {
        Task<RectangleDTO> GetRectangleAsync(CancellationToken cancellationToken);
        Task UpdateRectangleAsync(RectangleDTO rectangle, CancellationToken cancellationToken);
    }
}
