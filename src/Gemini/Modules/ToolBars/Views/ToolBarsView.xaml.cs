﻿using System.Windows.Controls;

namespace Gemini.Modules.ToolBars.Views
{
    /// <summary>
    /// Interaction logic for ToolBarsView.xaml
    /// </summary>
    public partial class ToolBarsView : UserControl, IToolBarsView
    {
        ToolBarTray IToolBarsView.ToolBarTray => ToolBarTray;

        public ToolBarsView() => InitializeComponent();
    }
}
