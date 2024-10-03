using System;
using System.Collections.Generic;
using System.Text;

namespace CommonControls.Interfaces
{
    /// <summary>
    /// Объект, имеющий именованные атрибуты
    /// </summary>
    public interface INamedAttributes
    {
        /// <summary>
        /// Возвращает атрибут
        /// </summary>
        /// <param name="name">Имя атрибута</param>
        /// <returns>Атрибут</returns>
        object this[string name]
        {
            get;
        }

        /// <summary>
        /// Имена всех атрибутов
        /// </summary>
        string[] Names
        {
            get;
        }

        /// <summary>
        /// Возвращает имя отображаемое на экране
        /// </summary>
        /// <param name="name">Имя объекта</param>
        /// <returns>Имя отображаемое на экране</returns>
        string GetDisplayName(string name);

        /// <summary>
        /// Объект по умлочанию
        /// </summary>
        /// <param name="name">Имя объекта</param>
        /// <returns>Объект по умолчанию</returns>
        object GetDefaultObject(string name);

    }
}
