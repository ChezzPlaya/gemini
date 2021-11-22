using System.Windows;
using System.Windows.Controls;

namespace Gemini.Modules.GraphEditor.Controls
{
    public class ElementItemsControl : ListBox
    {
        protected override DependencyObject GetContainerForItemOverride() => new ElementItem();

        protected override bool IsItemItsOwnContainerOverride(object item) => item is ElementItem;

        public ElementItemsControl() => SelectionMode = SelectionMode.Extended;
    }
}