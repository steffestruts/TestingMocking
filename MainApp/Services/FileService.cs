using MainApp.Interfaces;

namespace MainApp.Services;

public class FileService(string directoryPath = "Data", string fileName = "content.json") : IFileService
{
    private readonly string _directoryPath = directoryPath;
    private readonly string _filePath = Path.Combine(directoryPath, fileName);
    
    public bool SaveContentToFile(string content)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }
            File.WriteAllText(_filePath, content);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public string GetContentFromFile()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                return File.ReadAllText(_filePath);
            }
        }
        catch
        {
            return null!;
        }
        return null!;
    }
}