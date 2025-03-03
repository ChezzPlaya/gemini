﻿using System;
using System.Windows.Input;
using Caliburn.Micro;

namespace Gemini.Framework.Commands
{
    public abstract class CommandKeyboardShortcut
    {
        private readonly Func<CommandDefinitionBase> _commandDefinition;
        private readonly KeyGesture _keyGesture;
        private readonly int _sortOrder;

        public CommandDefinitionBase CommandDefinition => _commandDefinition();

        public KeyGesture KeyGesture => _keyGesture;

        public int SortOrder => _sortOrder;

        protected CommandKeyboardShortcut(KeyGesture keyGesture, int sortOrder, Func<CommandDefinitionBase> commandDefinition)
        {
            _commandDefinition = commandDefinition;
            _keyGesture = keyGesture;
            _sortOrder = sortOrder;
        }
    }

    public class CommandKeyboardShortcut<TCommandDefinition> : CommandKeyboardShortcut
        where TCommandDefinition : CommandDefinition
    {
        public CommandKeyboardShortcut(KeyGesture keyGesture, int sortOrder = 5)
            : base(keyGesture, sortOrder, () => IoC.Get<ICommandService>().GetCommandDefinition(typeof(TCommandDefinition)))
        {
            
        }
    }
}