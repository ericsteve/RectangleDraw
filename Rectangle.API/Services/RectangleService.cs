using Rectangle.API.Domain.Contracts;
using Rectangle.API.Models;
using Rectangle.API.Utils.Contracts;
using System.Text.Json;

namespace Rectangle.API.Services
{
    public class RectangleService : IRectangleService
    {
        private readonly IFileStorageUtil fileStorageUtil;
        private readonly string filePath;

        public RectangleService(IConfiguration configuration, IFileStorageUtil fileStorageUtil)
        {
            this.filePath = configuration["RecfangleFilePath"] ?? throw new ArgumentNullException("configuration");
            this.fileStorageUtil = fileStorageUtil;
        }

        public async Task<RectangleDTO> GetRectangleAsync(CancellationToken cancellationToken)
        {
            var json = await fileStorageUtil.ReadFromFileAsync(filePath, cancellationToken);
            return JsonSerializer.Deserialize<RectangleDTO>(json);
        }

        public async Task UpdateRectangleAsync(RectangleDTO rectangle, CancellationToken cancellationToken)
        {
            var json = JsonSerializer.Serialize(rectangle);
            await fileStorageUtil.WriteToFileAsync(filePath, json, cancellationToken);
        }
    }
}
