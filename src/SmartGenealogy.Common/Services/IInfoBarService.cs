using Microsoft.UI.Xaml.Controls;

namespace SmartGenealogy.Common.Services;

public interface IInfoBarService
{
    void ShowAppLevelInfoBar(InfoBarSeverity infoBarSeverity, string title, string message);

    void HideAppLevelInfoBar();

    bool IsAppLevelInfoBarVisible();
}