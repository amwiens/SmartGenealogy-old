using Avalonia.Controls;
using Avalonia;
using Avalonia.Styling;

using SmartGenealogy.Contracts;
using SmartGenealogy.Models;

using System.Text.Json;
using System.Text.Json.Nodes;

namespace SmartGenealogy.Services;

public class SettingService : ISettingService
{

    public SettingService()
    {

        LoadSavedSetting().Wait();
    }

    public Setting Settings { get; private set; } = new();

    public async Task InitializeSettings()
    {

        try
        {
            if (!File.Exists("Settings.json"))
            {

                //var screen = Screens.Primary;
                //var workingArea = screen.WorkingArea;

                //double dpiScaling = screen.PixelDensity;
                Settings.Width = 1300; // * dpiScaling;
                Settings.Height = 840; // * dpiScaling;

                Settings.X = 5;
                Settings.Y = 0;

            }

            var text = await File.ReadAllTextAsync("Settings.json");
            var settings = JsonSerializer.Deserialize<Setting>(text)!;

            Settings = settings.Clone();
        }
        catch (Exception ex)
        {

        }
    }

    public async Task OnChoosePath()
    {

    }

    private async Task LoadSavedSetting()
    {
        if (!File.Exists("Settings.json"))
            return;
        var text = await File.ReadAllTextAsync("Settings.json");
        //var settings = JsonNode.Parse(text);
        var settings = JsonSerializer.Deserialize<Setting>(text)!;
        //Settings.AppDataPath = settings?["AppDataPath"]?.ToString();
        //Settings.Width = double.Parse(settings?["Width"]?.ToString());
        //Settings.Height = double.Parse(settings?["Height"]?.ToString());
        //Settings.X = int.Parse(settings?["X"]?.ToString());
        //Settings.Y = int.Parse(settings?["Y"]?.ToString());
        //Settings.IsMaximized = bool.Parse(settings?["IsMaximized"]?.ToString());
        //Settings.FilePath = settings?["FilePath"]?.ToString();
        //Settings.CurrentTheme = (ThemeVariant)settings?["CurrentTheme"]?.ToString();
        Settings = settings.Clone();
    }
}