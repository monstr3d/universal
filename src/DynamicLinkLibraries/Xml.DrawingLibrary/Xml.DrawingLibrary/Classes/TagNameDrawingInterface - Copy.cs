using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using Xml.Drawing.Library.Interfaces;

namespace Xml.Drawing.Library.Classes
{
    /// <summary>
    /// Drawing structure provided by Xml document
    /// </summary>
    public class TagNameDrawingInterface : IDrawingStructure
    {
        #region Fields

        Dictionary<string, GraphicsStructure> dictionary;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dictionary">Dictionary of structures</param>
        public TagNameDrawingInterface(Dictionary<string, GraphicsStructure> dictionary)
        {
            this.dictionary = dictionary;
        }


        #endregion

        #region Specific Members

        /// <summary>
        /// Creates interface from dictionary
        /// </summary>
        /// <param name="dictionary">The dictionary</param>
        /// <returns>The interface</returns>
        public static IDrawingInterface GetInterface(Dictionary<string, GraphicsStructure> dictionary)
        {
            return new StrucureDrawingInterface(
                (new TagNameDrawingInterface(dictionary)  as IDrawingStructure).GetStructure);
        }

        #endregion

        #region IDrawingStructure Members

        GraphicsStructure IDrawingStructure.GetStructure(XElement element)
        {
            string tn = element.Name.LocalName;
            if (dictionary.ContainsKey(tn))
            {
                return dictionary[tn];
            }
            return null;
        }

        #endregion
    }
}
