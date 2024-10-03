using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CommonControls.Interfaces
{
    /// <summary>
    /// ��������� �������� ���������� ���������������� ���������� �� Xml
    /// </summary>
    public interface IControlCreator
    {
        /// <summary>
        /// ��������� UI ������� 
        /// </summary>
        /// <param name="e">Xml ������� - ��������</param>
        /// <returns>UI �������</returns>
        Control Load(XmlElement e);

        /// <summary>
        /// ��������� �������� UI ��������
        /// </summary>
        /// <param name="control">UI �������</param>
        /// <param name="e">Xml �������</param>
        void Load(Control control, XmlElement e);


        /// <summary>
        /// ��������� UI ������� � Xml �������
        /// </summary>
        /// <param name="control">UI �������</param>
        /// <param name="doc">������������ ��������</param>
        /// <returns>Xml �������</returns>
        XmlElement Save(Control control, XmlDocument doc);

        /// <summary>
        /// ��������� �������� �������� ����������������� ����������
        /// </summary>
        /// <param name="control">������� ����������������� ����������</param>
        /// <param name="element">Xml ������ �������</param>
        /// <param name="doc">����������� ��������</param>
        void Save(Control control, XmlElement element, XmlDocument doc);


    }
}
