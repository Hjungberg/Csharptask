
using Biz.Interfaces;
using Biz.Services;

namespace Tests.Services;

public class FileServiceTests
{

    [Fact]
    public void SaveContentToFile_ShouldSaveContentToAFile()
    {

        var content = "test";
        var fileName = $"{Guid.NewGuid().ToString()}.json";
        IFileService fileService = new FileService("data", fileName);

        try
        {
            var result = fileService.SaveContentToFile(content);

            Assert.True(result);
        }
        finally 
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
          
        }
    }
    [Fact]
    public void GetContentFromFile_ShoudReturnContentFromFile()
    {

        var content = "test";
        var fileName = $"{Guid.NewGuid().ToString()}.json";
        File.WriteAllText(fileName, content);

        IFileService fileService = new FileService("data", fileName);
        fileService.SaveContentToFile(content);

        try
        {
            var result = fileService.GetContentFromFile();

            Assert.Equal(content, result);
        }
        finally
        {
            if (File.Exists(fileName))
                File.Delete(fileName);

        }
    }

}

