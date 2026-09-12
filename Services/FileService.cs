using CatFactsApp.Interfaces;

namespace CatFactsApp.Services;

public class FileService : IFileService
{
    public void SaveFact(string fact)
    {
        File.AppendAllText(
            "catfacts.txt",
            $"{fact}{Environment.NewLine}"
        );
    }
}