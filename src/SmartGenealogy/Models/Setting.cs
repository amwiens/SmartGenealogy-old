using Avalonia.Styling;

namespace SmartGenealogy.Models;

public class Setting
{
    /// <summary>
    /// Application data path.
    /// </summary>
    public string? AppDataPath { get; set; }

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
    public ThemeVariant? CurrentTheme { get; set; }

    /// <summary>
    /// Language code.
    /// </summary>
    public string? LanguageCode { get; set; }

    public Setting Clone()
    {
        return (Setting)MemberwiseClone();
    }
}