using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CommonControls.Interfaces
{
    /// <summary>
    /// Интерфейс создания эленментов пользователского интерфейса из Xml
    /// </summary>
    public interface IControlCreator
    {
        /// <summary>
        /// Загружает UI элемент 
        /// </summary>
        /// <param name="e">Xml элемент - прототип</param>
        /// <returns>UI элемент</returns>
        Control Load(XmlElement e);

        /// <summary>
        /// Загружает свойства UI элемента
        /// </summary>
        /// <param name="control">UI элемент</param>
        /// <param name="e">Xml элемент</param>
        void Load(Control control, XmlElement e);


        /// <summary>
        /// Сохраняет UI элемент в Xml элемент
        /// </summary>
        /// <param name="control">UI элемент</param>
        /// <param name="doc">Родительский документ</param>
        /// <returns>Xml элемент</returns>
        XmlElement Save(Control control, XmlDocument doc);

        /// <summary>
        /// Сохраняет свойства элемента пользовательского интерфейса
        /// </summary>
        /// <param name="control">Элемент пользовательского интерфейса</param>
        /// <param name="element">Xml элемет свойств</param>
        /// <param name="doc">Родителский документ</param>
        void Save(Control control, XmlElement element, XmlDocument doc);


    }
}
