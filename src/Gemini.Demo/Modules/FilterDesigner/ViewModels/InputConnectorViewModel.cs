﻿using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Gemini.Demo.Modules.FilterDesigner.ViewModels
{
    public class InputConnectorViewModel : ConnectorViewModel
    {
        public event EventHandler SourceChanged;

        public override ConnectorDirection ConnectorDirection => ConnectorDirection.Input;

        private ConnectionViewModel _connection;
        public ConnectionViewModel Connection
        {
            get => _connection;
            set
            {
                if (_connection != null)
                    _connection.From.Element.OutputChanged -= OnSourceElementOutputChanged;
                _connection = value;
                if (_connection != null)
                    _connection.From.Element.OutputChanged += OnSourceElementOutputChanged;
                RaiseSourceChanged();
                NotifyOfPropertyChange(() => Connection);
            }
        }

        private void OnSourceElementOutputChanged(object sender, EventArgs e) => RaiseSourceChanged();

        public BitmapSource Value
        {
            get
            {
                if (Connection == null || Connection.From == null)
                    return null;

                return Connection.From.Value;
            }
        }

        public InputConnectorViewModel(ElementViewModel element, string name, Color color)
            : base(element, name, color)
        {
            
        }

        private void RaiseSourceChanged() => SourceChanged?.Invoke(this, EventArgs.Empty);
    }
}