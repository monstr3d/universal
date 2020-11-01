using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CommonControls.Interfaces
{
    /// <summary>
    /// Фабрика создания элементов клише
    /// </summary>
    public interface IControlFactory
    {
        /// <summary>
        /// Создаёт элемент клише
        /// </summary>
        /// <param name="attr">Объект атрибутов по умолчанию</param>
        /// <param name="name">Имя элемента клише</param>
        /// <returns>Элемент клише</returns>
        Control this[INamedAttributes attr, string name]
        {
            get;
        }
    }
}
