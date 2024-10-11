using Motion6D.Portable.Interfaces;

namespace Motion6D.Portable
{
    public class EmptyComeraConsumer : ICameraConsumer
    {
        void ICameraConsumer.Add(Camera camera)
        {
        }

        void ICameraConsumer.Remove(Camera camera)
        {
        }
    }
}
