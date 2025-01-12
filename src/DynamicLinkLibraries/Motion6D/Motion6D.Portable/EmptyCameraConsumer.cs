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

        protected double[,] size;


   
        public EmptyCameraConsumer(IPosition position, double[,] size = null) 
        {
            this.position = position;
            this.size = size;
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

        double[,] IVisible.Size => size;
    }
}