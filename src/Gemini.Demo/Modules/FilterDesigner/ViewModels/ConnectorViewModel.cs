﻿using System;
using System.Windows;
using System.Windows.Media;
using Caliburn.Micro;

namespace Gemini.Demo.Modules.FilterDesigner.ViewModels
{
    public enum ConnectorDataType
    {
        
    }

    public abstract class ConnectorViewModel : PropertyChangedBase
    {
        public event EventHandler PositionChanged;

        private readonly ElementViewModel _element;
        public ElementViewModel Element => _element;

        private readonly string _name;
        public string Name => _name;

        private readonly Color _color = Colors.Black;
        public Color Color => _color;

        private Point _position;
        public Point Position
        {
            get => _position;
            set
            {
                _position = value;
                NotifyOfPropertyChange(() => Position);
                RaisePositionChanged();
            }
        }

        public abstract ConnectorDirection ConnectorDirection { get; }

        protected ConnectorViewModel(ElementViewModel element, string name, Color color)
        {
            _element = element;
            _name = name;
            _color = color;
        }

        private void RaisePositionChanged() => PositionChanged?.Invoke(this, EventArgs.Empty);
    }
}