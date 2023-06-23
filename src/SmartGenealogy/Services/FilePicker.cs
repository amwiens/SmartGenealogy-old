namespace SmartGenealogy.Services;

public class FilePicker
{
    private static FilePicker _instance;

    public static FilePicker Instance
    {
        get
        {
            if (_instance == null)
                _instance = new FilePicker();

            return _instance;
        }
    }

    /// <summary>
    /// Convert byte[] to Stream
    /// </summary>
    /// <param name="bytes">byte[]</param>
    /// <returns>Stream</returns>
    public Stream ByteArrayToStream(byte[] bytes)
        => bytes is not null ? new MemoryStream(bytes) : null;

    /// <summary>
    /// Convert byte[] to string
    /// </summary>
    /// <param name="bytes">byte[]</param>
    /// <returns>string</returns>
    public string ByteBase64ToString(byte[] bytes)
        => bytes is not null ? Convert.ToBase64String(bytes) : null;

    /// <summary>
    /// Convert FileResult to stream
    /// </summary>
    /// <param name="fileResult">FileResult</param>
    /// <returns>Stream</returns>
    public Task<Stream> FileResultToStream(FileResult fileResult)
        => fileResult == null ? null : fileResult.OpenReadAsync();

    /// <summary>
    /// Open Media Picker
    /// </summary>
    /// <returns>Task</returns>
    public async Task<FileResult> OpenMediaPickerAsync()
    {
        try
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a photo"
            });

            if (result != null)
            {
                if (result.ContentType == "image/png" ||
                    result.ContentType == "image/jpeg" ||
                    result.ContentType == "image/jpg")
                    return result;
            }
            else
                await App.Current.MainPage.DisplayAlert("Error Type Image", "Please choose a new image", "Ok");

            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    /// <summary>
    /// Open Model Picker
    /// </summary>
    /// <returns>Task</returns>
    public async Task<FileResult> OpenModelPickerAsync()
    {
        try
        {
            var result = await Microsoft.Maui.Storage.FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Please pick a model"
            });

            if (result != null)
            {
                return result;
            }
            else
                await App.Current.MainPage.DisplayAlert("Error Type Image", "Please choose a new model", "Ok");

            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    /// <summary>
    /// Open Database Picker
    /// </summary>
    /// <returns>Task</returns>
    public async Task<FileResult> OpenDatabasePickerAsync()
    {
        try
        {
            var result = await Microsoft.Maui.Storage.FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Please pick a database"
            });

            if (result != null)
            {
                return result;
            }
            else
                await App.Current.MainPage.DisplayAlert("Error Type Image", "Please choose a new database", "Ok");

            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    /// <summary>
    /// Convert string to byte[]
    /// </summary>
    /// <param name="text">string</param>
    /// <returns>byte[]</returns>
    public byte[] StringToByteBase64(string text)
        => text is not null ? Convert.FromBase64String(text) : null;

    /// <summary>
    /// Upload an image
    /// </summary>
    /// <param name="fileResult">FileResult</param>
    /// <returns>ImageFile class</returns>
    public async Task<ImageFile> UploadImageFile(FileResult fileResult)
    {
        byte[] bytes;

        try
        {
            using (var ms = new MemoryStream())
            {
                if (fileResult is not null)
                {
                    var stream = await FileResultToStream(fileResult);
                    stream.CopyTo(ms);
                    bytes = ms.ToArray();

                    return new ImageFile
                    {
                        byteBase64 = ByteBase64ToString(bytes),
                        ContentType = fileResult.ContentType,
                        FileName = fileResult.FileName
                    };
                }
                else
                    return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}