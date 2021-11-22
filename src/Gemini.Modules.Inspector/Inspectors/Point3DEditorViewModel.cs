using System.Windows.Media.Media3D;

namespace Gemini.Modules.Inspector.Inspectors
{
    public class Point3DEditorViewModel : EditorBase<Point3D>, ILabelledInspector
    {
        public double X
        {
            get => Value.X;
            set
            {
                Value = new Point3D(value, Value.Y, Value.Z);
                NotifyOfPropertyChange(() => X);
            }
        }

        public double Y
        {
            get => Value.Y;
            set
            {
                Value = new Point3D(Value.X, value, Value.Z);
                NotifyOfPropertyChange(() => Y);
            }
        }

        public double Z
        {
            get => Value.Z;
            set
            {
                Value = new Point3D(Value.X, Value.Y, value);
                NotifyOfPropertyChange(() => Z);
            }
        }

        public override void NotifyOfPropertyChange(string propertyName)
        {
            if (propertyName == "Value")
            {
                NotifyOfPropertyChange(() => X);
                NotifyOfPropertyChange(() => Y);
                NotifyOfPropertyChange(() => Z);
            }
            base.NotifyOfPropertyChange(propertyName);
        }
    }
}