using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Gemini.Framework;
using Gemini.Framework.Services;
using Gemini.Modules.Inspector.Properties;

namespace Gemini.Modules.Inspector.ViewModels
{
    [Export(typeof(IInspectorTool))]
    public class InspectorViewModel : Tool, IInspectorTool
    {
        public event EventHandler SelectedObjectChanged;

        public override PaneLocation PreferredLocation => PaneLocation.Right;

        public override double PreferredWidth => 300;

        private IInspectableObject _selectedObject;

        public IInspectableObject SelectedObject
        {
            get => _selectedObject;
            set
            {
                _selectedObject = value;
                NotifyOfPropertyChange(() => SelectedObject);
                RaiseSelectedObjectChanged();
            }
        }

        public InspectorViewModel() => DisplayName = Resources.InspectorDisplayName;

        private void RaiseSelectedObjectChanged() => SelectedObjectChanged?.Invoke(this, EventArgs.Empty);

        public void ResetAll()
        {
            if (SelectedObject == null)
                return;

            RecurseEditors(SelectedObject.Inspectors, delegate(Inspectors.IEditor editor) {
                if (editor != null && editor.CanReset)
                    editor.Reset();
            });
        }

        public void RecurseEditors(IEnumerable<Inspectors.IInspector> inspectors, Action<Inspectors.IEditor> action)
        {
            foreach (var inspector in inspectors)
            {
                if (inspector is Inspectors.CollapsibleGroupViewModel group)
                {
                    RecurseEditors(group.Children, action);
                }
                else
                {
                    action(inspector as Inspectors.IEditor);
                }
            }
        }
    }
}