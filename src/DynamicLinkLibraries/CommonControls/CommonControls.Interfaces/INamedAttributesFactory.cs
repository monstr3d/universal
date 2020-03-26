using System;
using System.Collections.Generic;
using System.Text;

namespace CommonControls.Interfaces
{
    /// <summary>
    /// Фабрика объетов отображаемых на экране
    /// </summary>
    public interface INamedAttributesFactory
    {
        /// <summary>
        /// Объект по умолчанию
        /// </summary>
        INamedAttributes Default
        {
            get;
        }

        /// <summary>
        /// Возвращает объект с заданным Id
        /// </summary>
        /// <param name="id">Id объекта</param>
        /// <returns></returns>
        INamedAttributes this[object id]
        {
            get;
        }

    }
}
