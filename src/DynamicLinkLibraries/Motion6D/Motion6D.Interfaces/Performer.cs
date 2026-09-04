namespace Motion6D.Interfaces
{
    public class Performer
    {
        public Performer() { }

        public ReferenceFrame GetParentOwn(IPosition position)
        {
            var p = position.Parent;
            if (p is IReferenceFrame rf)
            {
                return rf.Own;
            }
            return null;
        }

    }
}
