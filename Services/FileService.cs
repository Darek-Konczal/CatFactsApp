namespace CatFactsApp.Services;

public class FileService
{
    public void SaveFact(string fact)
    {
        File.AppendAllText(
            "catfacts.txt",
            $"{fact}{Environment.NewLine}"
        );
    }
}