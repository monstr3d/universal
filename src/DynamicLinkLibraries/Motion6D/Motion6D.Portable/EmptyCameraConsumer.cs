using CategoryTheory;
using Motion6D.Interfaces;
using Motion6D.Portable.Interfaces;
using System;

namespace Motion6D.Portable
{
    public class EmptyCameraConsumer : ICategoryObject, ICameraConsumer, IVisible
    {
        IPosition position;

        object obj;


        public EmptyCameraConsumer(IPosition position)
        {
            this.position = position;
        }

        void ICameraConsumer.Add(Camera camera)
        {
        }

        void ICameraConsumer.Remove(Camera camera)
        {
        }

        IPosition IPositionObject.Position
        {
            get => position;
            set { }
        }


        object IAssociatedObject.Object 
        { 
            get => obj; 
            set => obj = value; 
        }
    }
}