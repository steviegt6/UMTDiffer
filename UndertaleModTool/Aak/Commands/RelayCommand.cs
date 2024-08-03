﻿using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace UndertaleModTool.Aak.Commands;

/// <summary>
///     Wrapper around <see cref="ICommand"/> that allows for easy declaration
///     of commands through delegates.
/// </summary>
internal sealed class RelayCommand : ICommand
{
    private readonly Action      execute;
    private readonly Func<bool>? canExecute;

    public event EventHandler? CanExecuteChanged;

    public RelayCommand(Action execute)
    {
        this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
    }

    public RelayCommand(Action execute, Func<bool> canExecute)
    {
        this.execute    = execute    ?? throw new ArgumentNullException(nameof(execute));
        this.canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
    }

    public void NotifyCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool CanExecute(object? parameter)
    {
        return canExecute?.Invoke() ?? true;
    }

    public void Execute(object? parameter)
    {
        execute();
    }
}