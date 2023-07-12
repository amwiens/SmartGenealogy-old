/*
 * Taken from: https://www.code4it.dev/blog/download-and-save-files/
 */

namespace SmartGenealogy.Core.Helpers;

public static class FileDownload
{
    public static async Task DownloadAndSave(string sourceFile, string destinationFolder, string destinationFileName)
    {
        Stream fileStream = await GetFileStream(sourceFile);

        if (fileStream != Stream.Null)
        {
            await SaveStream(fileStream, destinationFolder, destinationFileName);
        }
    }

    public static async Task<Stream> GetFileStream(string fileUrl)
    {
        HttpClient httpClient = new HttpClient();
        try
        {
            Stream fileStream = await httpClient.GetStreamAsync(fileUrl);
            return fileStream;
        }
        catch (Exception ex)
        {
            return Stream.Null;
        }
    }

    public static async Task SaveStream(Stream fileStream, string destinationFolder, string destinationFileName)
    {
        if (!Directory.Exists(destinationFolder))
            Directory.CreateDirectory(destinationFolder);

        string path = Path.Combine(destinationFolder, destinationFileName);

        using (FileStream outputFileStream = new FileStream(path, FileMode.CreateNew))
        {
            await fileStream.CopyToAsync(outputFileStream);
        }
    }
}