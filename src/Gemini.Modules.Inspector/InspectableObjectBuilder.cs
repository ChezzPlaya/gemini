namespace Gemini.Modules.Inspector
{
    public class InspectableObjectBuilder : InspectorBuilder<InspectableObjectBuilder>
    {
        public InspectableObject ToInspectableObject() => new InspectableObject(Inspectors);
    }
}