using Caliburn.Micro;

namespace Gemini.Modules.UndoRedo.ViewModels
{
    public class HistoryItemViewModel : PropertyChangedBase
    {
        private readonly IUndoableAction _action;

        public IUndoableAction Action => _action;

        private readonly string _name;
        public string Name => _name ?? _action.Name;

        private HistoryItemType _itemType;
        public HistoryItemType ItemType
        {
            get => _itemType;
            set
            {
                if (_itemType == value)
                    return;

                _itemType = value;

                NotifyOfPropertyChange(() => ItemType);
            }
        }

        public HistoryItemViewModel(IUndoableAction action) => _action = action;

        public HistoryItemViewModel(string name) => _name = name;
    }
}
