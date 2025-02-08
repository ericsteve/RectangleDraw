using Rectangle.API.Utils.Contracts;

namespace Rectangle.API.Utils.Files
{
    public class FileStorageUtil : IFileStorageUtil
    {
        public async Task<string> ReadFromFileAsync(string filePath, CancellationToken cancellationToken)
        {
            return await File.ReadAllTextAsync(filePath, cancellationToken);
        }

        public async Task WriteToFileAsync(string filePath, string content, CancellationToken cancellationToken)
        {
            await File.WriteAllTextAsync(filePath, content, cancellationToken);
        }
    }
}
