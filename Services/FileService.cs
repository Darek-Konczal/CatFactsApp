using Microsoft.Extensions.Configuration;
using CatFactsApp.Interfaces;

namespace CatFactsApp.Services;

public class FileService : IFileService
{
    private readonly string _filePath;

    public FileService(IConfiguration configuration)
    {
        _filePath = configuration["File:Path"]
            ?? throw new InvalidOperationException("File:Path is not configured.");
    }

    public void SaveFact(string fact)
    {
        File.AppendAllText(
            _filePath,
            $"{fact}{Environment.NewLine}"
        );
    }
}