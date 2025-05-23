using System.Collections.Generic;
using Unity.Standard.Interfaces;
using UnityEngine;

namespace Unity.Standard
{
    /// <summary>
    /// Blinks Game objects
    /// </summary>
    public class BlinkedEnabledGameObjects : IBlinked
    {
        #region Fields
        
        GameObject[] objects;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="objects">Objects</param>
        public BlinkedEnabledGameObjects(IEnumerable<GameObject> objects)
        {
            this.objects = (new List<GameObject>(objects)).ToArray();
        }

        #endregion

        #region IBlinked implementation

        bool IBlinked.IsStopped { get; set; }

        void IBlinked.Blink(int i)
        {
            bool b = (i % 2) == 0;
            foreach (var a in objects)
            {
                a.SetActive(b);
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        ///  Disables controls
        /// </summary>
        public void Disable()
        {
            foreach (var o in objects)
            {
                o.SetActive(false);
            }
        }

        #endregion
    }
}
