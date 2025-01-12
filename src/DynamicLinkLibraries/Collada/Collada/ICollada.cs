using System.Xml;

namespace Collada
{
    public interface ICollada
    {

        /// <summary>
        /// The unique id of element
        /// </summary>
        /// <param name="xmlElement">TheElement</param>
        /// <returns>The unique id</returns>
        string UniqueId(XmlElement xmlElement);

        /// <summary>
        /// Clears itself
        /// </summary>
        void Clear();

        /// <summary>
        /// Puts Xml element
        /// </summary>
        /// <param name="xmlElement"></param>
        void Put(XmlElement xmlElement);

        /// <summary>
        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="xmlElement"></param>
        void Init(XmlElement xmlElement);

        /// <summary>
        /// Gets object from string
        /// </summary>
        /// <param name="s">The string</param>
        /// <returns>The object</returns>
        object Get(string s);


        /// <summary>
        /// File name
        /// </summary>
        string Filename { get; set; }

    }
}
