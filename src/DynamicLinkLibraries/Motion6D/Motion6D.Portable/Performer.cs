
using System.Collections.Generic;
using Motion6D.Interfaces;

namespace Motion6D.Portable
{
    public class Performer 
    {
       NamedTree.Comparer<IPosition> comparer = new ();

        /// <summary>
        /// Updates frames
        /// </summary>
        /// <param name="frames">Frames</param>
        public void UpdateFrames(IEnumerable<IPosition> frames)
        {
            foreach (IPosition frame in frames)
            {
                frame.Update();
            }
        }

        /// <summary>
        /// Sorts positions
        /// </summary>
        /// <param name="positions">Positions</param>
        public void SortPositions(List<IPosition> positions)
        {
            comparer.Sort(positions);
        }
    }
}

