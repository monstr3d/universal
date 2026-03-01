using System;
using Unity.Standard.Interfaces;

namespace Unity.Standard.Abstract
{
    /// <summary>
    /// Constructor
    /// </summary>
    public abstract class AbstractLevelStringUpdate : IStringUpdate
    {
        static public readonly string Level = "Level";

        static bool first = true;

        protected int level = 0;

        protected string post;

        protected Action update;

        protected AbstractLevelStringUpdate()
        {
            if (!first)
            {
                throw new Exception();
            }
            first = true;
            level = StaticExtensionUnity.Activation.level;
            StaticExtensionUnity.OnGlobal += Update;
        }

        Action IStringUpdate.UpdateItself => update;


        /// <summary>
        /// Updates string
        /// </summary>
        /// <param name="str">The string parameter</param>
        public void Update(string str)
        {
            int k = str.IndexOf(":");
            if (k < 0)
            {
                return;
            }
            if (str.Substring(0, k) != Level)
            {
                return;
            }
            post = str.Substring(k + 1);
            k = post.IndexOf(":");
            int l = int.Parse(post.Substring(0, k));
            if (l != level)
            {
                return;
            }
            post = post.Substring(k + 1);
        }

   
    }
}
