using System;
using System.ComponentModel;
using Gemini.Modules.Inspector.Inspectors;

namespace Gemini.Modules.Inspector.Conventions
{
    public class EnumPropertyEditorBuilder : PropertyEditorBuilder
    {
        public override bool IsApplicable(PropertyDescriptor propertyDescriptor) => typeof(Enum).IsAssignableFrom(propertyDescriptor.PropertyType);

        public override IEditor BuildEditor(PropertyDescriptor propertyDescriptor) => new EnumEditorViewModel(propertyDescriptor.PropertyType);
    }
}