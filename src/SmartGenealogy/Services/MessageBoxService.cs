﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia.Models;

using SmartGenealogy.Contracts;

using static SmartGenealogy.Localization.Resources;

namespace SmartGenealogy.Services;

public class MessageBoxService : IMessageBoxService
{
    public Lazy<ISettingService>? SettingService { get; init; }

    public async Task<ButtonResult> CreateMessageBox(string title, string content, ButtonEnum button = ButtonEnum.Ok, Icon icon = Icon.Success)
    {
        var desktop = Application.Current!.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime;
        var isMainWindow = desktop?.MainWindow is not null;
        var messageBox = MessageBoxManager
            .GetMessageBoxStandard(new MessageBoxStandardParams
            {
                ContentTitle = title,
                ContentMessage = content,
                ButtonDefinitions = button,
                Icon = icon,
                Topmost = true,
                //FontFamily = SettingService.Value.Settings.FontName,
                WindowStartupLocation = isMainWindow ? WindowStartupLocation.CenterOwner : WindowStartupLocation.CenterScreen
            });
        return isMainWindow ? await messageBox.ShowWindowDialogAsync(desktop!.MainWindow) : await messageBox.ShowAsync();
    }

    public async Task<ButtonResult> CreateNoticeMessageBox(string content, Icon icon = Icon.Info) =>
        await CreateMessageBox(MsgBox_Title_Notice, content, icon: icon);

    public async Task<ButtonResult> CreateSuccessMessageBox(string content, Icon icon = Icon.Success) =>
        await CreateMessageBox(MsgBox_Title_Success, content, icon: icon);

    public async Task<ButtonResult> CreateWarningMessageBox(string content, Icon icon = Icon.Warning) =>
        await CreateMessageBox(MsgBox_Title_Warning, content, icon: icon);

    public async Task<ButtonResult> CreateErrorMessageBox(string title, string content) =>
        await CreateMessageBox(title, content, icon: Icon.Error);

    public async Task<ButtonResult> CreateErrorMessageBox(string content) =>
        await CreateMessageBox(MsgBox_Title_Failure, content);

    public async Task<bool> CreateConfirmMessageBox(string title, string content)
    {
        var result = await CreateCustomConfirmMessageBox(title, content, 2, Icon.Warning);
        return result == MsgBox_Button_Yes;
    }

    public async Task<bool> CreateConfirmMessageBox(string content) => await CreateConfirmMessageBox(MsgBox_Title_Warning, content);

    public async Task<string> CreateCustomMessageBox(string title, string content, IEnumerable<ButtonDefinition> buttonDefinitions, Icon icon)
    {
        var desktop = Application.Current!.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime;
        var isMainWindow = desktop?.MainWindow is not null;
        var messageBox = MessageBoxManager
            .GetMessageBoxCustom(new MessageBoxCustomParams
            {
                ContentTitle = title,
                ContentMessage = content,
                ButtonDefinitions = buttonDefinitions,
                Icon = icon,
                CanResize = true,
                Topmost = true,
                //FontFamily = SettingService.Value.Settings.FontName,
                WindowStartupLocation = isMainWindow ? WindowStartupLocation.CenterOwner : WindowStartupLocation.CenterScreen
            });
        return isMainWindow ? await messageBox.ShowWindowDialogAsync(desktop!.MainWindow) : await messageBox.ShowAsync();
    }

    public async Task<string> CreateCustomConfirmMessageBox(string title, string content, int buttonCount, Icon icon)
    {
        var buttonDefinitions = buttonCount switch
        {
            3 => new[]
            {
                new ButtonDefinition { Name = MsgBox_Button_Yes, IsDefault = true },
                new ButtonDefinition { Name = MsgBox_Button_No, IsCancel = true },
                new ButtonDefinition { Name = MsgBox_Button_NoNoAsk, IsCancel = true }
            },
            4 => new[]
            {
                new ButtonDefinition { Name = MsgBox_Button_Yes, IsDefault = true },
                new ButtonDefinition { Name = MsgBox_Button_YesNoAsk, IsCancel = false },
                new ButtonDefinition { Name = MsgBox_Button_No, IsCancel = true },
                new ButtonDefinition { Name = MsgBox_Button_NoNoAsk, IsCancel = true }
            },
            _ => new[]
            {
                new ButtonDefinition { Name = MsgBox_Button_Yes, IsDefault = true },
                new ButtonDefinition { Name = MsgBox_Button_No, IsCancel = true },
            }
        };

        return await CreateCustomMessageBox(title, content, buttonDefinitions, Icon.Info);
    }

    public async Task<string> CreateCustomConfirmMessageBox(string content, int buttonCount) =>
        await CreateCustomConfirmMessageBox(MsgBox_Title_Notice, content, buttonCount, Icon.Info);
}