﻿using Caliburn.Micro;

namespace Gemini.Modules.ErrorList
{
    public class ErrorListItem : PropertyChangedBase
    {
        private ErrorListItemType _itemType;
        public ErrorListItemType ItemType
        {
            get => _itemType;
            set
            {
                _itemType = value;
                NotifyOfPropertyChange(() => ItemType);
            }
        }

        private int _number;
        public int Number
        {
            get => _number;
            set
            {
                _number = value;
                NotifyOfPropertyChange(() => Number);
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        private string _path;
        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                NotifyOfPropertyChange(() => _path);
                NotifyOfPropertyChange("File");
            }
        }

        public string File => System.IO.Path.GetFileName(Path);

        private int? _line;
        public int? Line
        {
            get => _line;
            set
            {
                _line = value;
                NotifyOfPropertyChange(() => Line);
            }
        }

        private int? _column;
        public int? Column
        {
            get => _column;
            set
            {
                _column = value;
                NotifyOfPropertyChange(() => Column);
            }
        }

        public System.Action OnClick { get; set; }

        public ErrorListItem(ErrorListItemType itemType, int number, string description,
            string path = null, int? line = null, int? column = null)
        {
            _itemType = itemType;
            _number = number;
            _description = description;
            _path = path;
            _line = line;
            _column = column;
        }

        public ErrorListItem()
        {
            
        }
    }
}