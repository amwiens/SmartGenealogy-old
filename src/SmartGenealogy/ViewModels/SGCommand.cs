﻿using System.Windows.Input;

namespace SmartGenealogy.ViewModels;

public class SGCommand : ICommand
{
    public SGCommand(Action<object> executeMethod)
    {
        _executeMethod = executeMethod;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        _executeMethod.Invoke(parameter);
    }

    private Action<object> _executeMethod;
}