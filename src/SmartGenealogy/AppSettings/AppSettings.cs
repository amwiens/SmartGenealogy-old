using Avalonia.Styling;

namespace SmartGenealogy.AppSettings;

public class AppSettings
{
    private static AppSettings _instance;

    public static AppSettings Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AppSettings();
            }

            return _instance;
        }
    }

    /// <summary>
    /// Application data path.
    /// </summary>
    public string AppDataPath { get; }
    /// <summary>
    /// Width of the main window.
    /// </summary>
    public double Width { get; set; }
    /// <summary>
    /// Height of the main window.
    /// </summary>
    public double Height { get; set; }
    /// <summary>
    /// Position X of the main window.
    /// </summary>
    public int X { get; set; }
    /// <summary>
    /// Position Y of the main window.
    /// </summary>
    public int Y { get; set; }
    /// <summary>
    /// Is the main window maximized.
    /// </summary>
    public bool IsMaximized { get; set; }
    /// <summary>
    /// File path for the last open file.
    /// </summary>
    public string? FilePath { get; set; }
    /// <summary>
    /// Current theme.
    /// </summary>
    public ThemeVariant CurrentTheme { get; set; }

    public AppSettings()
    {
        AppDataPath = GetAppDataDirectory();
    }

    private string GetAppDataDirectory()
    {
        string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SmartGenealogy");
        if (!Directory.Exists(appDataPath))
        {
            Directory.CreateDirectory(appDataPath);
        }
        return appDataPath;
    }
}