using System;
using System.Windows;

namespace Gemini.Modules.Inspector.Controls
{
    public class InspectorGrid
    {
        public static event EventHandler PropertyNameColumnWidthChanged;
        public static event EventHandler PropertyValueColumnWidthChanged;

        private static GridLength _propertyNameColumnWidth = new GridLength(1, GridUnitType.Star);
        public static GridLength PropertyNameColumnWidth
        {
            get => _propertyNameColumnWidth;
            set
            {
                _propertyNameColumnWidth = value;
                PropertyNameColumnWidthChanged?.Invoke(null, EventArgs.Empty);
            }
        }


        private static GridLength _propertyValueColumnWidth = new GridLength(1.5, GridUnitType.Star);
        public static GridLength PropertyValueColumnWidth
        {
            get => _propertyValueColumnWidth;
            set
            {
                _propertyValueColumnWidth = value;
                PropertyValueColumnWidthChanged?.Invoke(null, EventArgs.Empty);
            }
        }
    }
}
