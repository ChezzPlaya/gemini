using System;
using System.Windows.Input;
using Gemini.Framework.Commands;

namespace Gemini.Framework.ToolBars
{
    public abstract class ToolBarItemDefinition
    {
        private readonly ToolBarItemGroupDefinition _group;
        private readonly int _sortOrder;
        private readonly ToolBarItemDisplay _display;

        public ToolBarItemGroupDefinition Group => _group;

        public int SortOrder => _sortOrder;

        public ToolBarItemDisplay Display => _display;

        public abstract string Text { get; }
        public abstract Uri IconSource { get; }
        public abstract KeyGesture KeyGesture { get; }
        public abstract CommandDefinitionBase CommandDefinition { get; }

        protected ToolBarItemDefinition(ToolBarItemGroupDefinition group, int sortOrder, ToolBarItemDisplay display)
        {
            _group = group;
            _sortOrder = sortOrder;
            _display = display;
        }
    }

    public enum ToolBarItemDisplay
    {
        IconOnly,
        IconAndText
    }
}
