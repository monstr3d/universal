using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace CommonControls.Interfaces
{
    /// <summary>
    /// Всомогательный интерфес, предназначенный
    /// для сериализации элемента пользователского интерфейса
    /// </summary>
    public interface ISerializableControl
    {
        /// <summary>
        /// Свойства объекта которые могут быть представлены
        /// в виде осмысленных строк
        /// </summary>
        Dictionary<string, string> Properties
        {
            get;
            set;
        }

        /// <summary>
        /// Дочерние элементы пользовательского интерфейса.
        /// </summary>
        List<ISerializable> Controls
        {
            get;
            set;
        }

        /// <summary>
        /// Свойства объекта, являющиеся сериализуемыми объектами.
        /// </summary>
        Dictionary<string, ISerializable> Other
        {
            get;
            set;
        }
    }
}
