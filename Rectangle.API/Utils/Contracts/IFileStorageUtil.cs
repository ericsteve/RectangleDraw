namespace Rectangle.API.Utils.Contracts
{
    public interface IFileStorageUtil
    {
        Task WriteToFileAsync(string filePath, string content, CancellationToken cancellationToken);
        Task<string> ReadFromFileAsync(string filePath, CancellationToken cancellationToken);
    }
}
