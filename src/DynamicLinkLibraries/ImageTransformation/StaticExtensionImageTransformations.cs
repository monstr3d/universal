using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageTransformations
{
    /// <summary>
    /// Static extension
    /// </summary>
    static public class StaticExtensionImageTransformations
    {
        public static void FourFillQueue(Bitmap source, Bitmap target,
            Func<Bitmap,Bitmap, int, int, bool> initiate, 
            Func<Bitmap, Bitmap, int, int, bool> predicate, 
            Func<Bitmap, Bitmap, int, int, bool> processed, 
            Action<Bitmap,Bitmap, int, int> process)
        {
            //Enqueuing
            Queue<PointInt> q = new Queue<PointInt>();
            for (int i = 0; i< source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    if (initiate(source, target, i, j))
                    {
                        q.Enqueue(new PointInt(i, j));
                    }
                }
            }

            while(q.Count > 0)
            {
                PointInt p = q.Dequeue();
                if (!predicate(source, target, p.X, p.Y) | processed(source, target, p.X, p.Y))
                {
                    continue;
                }
                int e = p.X;
                while (e < source.Width - 1 & predicate(source, target, e, p.Y))
                {
                    e++;
                }
                int w = p.X;
                while (w > 0 & predicate(source, target, w, p.Y))
                {
                    w--;
                }


                if (p.Y < source.Height - 1)
                {
                    for (int i = w; i <= e; i++)
                    {
                        process(source, target, i, p.Y);
                        if (!(processed(source, target, i, p.Y + 1)))
                        {
                            q.Enqueue(new PointInt(i, p.Y + 1));
                        }
                    }
                }

                if (p.Y > 0)
                {
                    for (int i = w; i <= e; i++)
                    {
                        process(source, target, i, p.Y);
                        if (!(processed(source, target, i, p.Y - 1)))
                        {
                            q.Enqueue(new PointInt(i, p.Y - 1));
                        }
                    }
                }
            }
        }

        internal class PointInt
        {
            int x;
            int y;

            internal PointInt(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            internal int X
            {
                get
                {
                    return x;
                }
            }

            internal int Y
            {
                get
                {
                    return y;
                }
            }


        }
    }
}
