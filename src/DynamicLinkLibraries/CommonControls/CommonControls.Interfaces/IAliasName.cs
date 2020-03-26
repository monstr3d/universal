using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonControls.Interfaces
{
    /// <summary>
    /// Объект, имеющий псевдоним
    /// Данный интерфейс применяется для загружаемых
    /// элементов пользователского интерфейса
    /// </summary>
    public interface IAliasName
    {

        /// <summary>
        /// Псевдоним
        /// </summary>
        string AliasName
        {
            get;
            set;
        }

        /// <summary>
        /// Ассоциированный объект. Данным объектом
        /// для клише является текст или картинка
        /// </summary>
        object Object
        {
            set;
        }

        /// <summary>
        /// Флаг статичности. Если объект статичен, то его поведение
        /// не меняется при загрузке данных
        /// </summary>
        bool IsStatic
        {
            get;
            set;
        }

        /// <summary>
        /// Имя объекта в редакторе свойств
        /// </summary>
        string DisplayName
        {
            get;
            set;
        }

        /// <summary>
        /// Номер элемента
        /// </summary>
        int Number
        {
            get;
            set;
        }

        /// <summary>
        /// Имя элемента
        /// </summary>
        string ElementName
        {
            get;
            set;
        }

    }
}
