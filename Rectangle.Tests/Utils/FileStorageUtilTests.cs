using Rectangle.API.Utils.Files;

namespace Rectangle.Tests.Utils
{
    public class FileStorageUtilTests
    {
        private readonly FileStorageUtil _fileStorageUtil;

        public FileStorageUtilTests()
        {
            _fileStorageUtil = new FileStorageUtil();
        }

        [Fact]
        public async Task ReadFromFileAsync_ShouldReturnFileContent()
        {
            var filePath = "testfile.txt";
            var expectedContent = "Hello, World!";
            await File.WriteAllTextAsync(filePath, expectedContent);

            var content = await _fileStorageUtil.ReadFromFileAsync(filePath, CancellationToken.None);

            Assert.Equal(expectedContent, content);

            File.Delete(filePath);
        }

        [Fact]
        public async Task WriteToFileAsync_ShouldWriteContentToFile()
        {
            var filePath = "testfile.txt";
            var content = "Hello, World!";

            await _fileStorageUtil.WriteToFileAsync(filePath, content, CancellationToken.None);

            var fileContent = await File.ReadAllTextAsync(filePath);
            Assert.Equal(content, fileContent);

            File.Delete(filePath);
        }
    }
}

