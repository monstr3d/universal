using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CommonControls.Interfaces
{
    /// <summary>
    /// ������� �������� ��������� �����
    /// </summary>
    public interface IControlFactory
    {
        /// <summary>
        /// ������ ������� �����
        /// </summary>
        /// <param name="attr">������ ��������� �� ���������</param>
        /// <param name="name">��� �������� �����</param>
        /// <returns>������� �����</returns>
        Control this[INamedAttributes attr, string name]
        {
            get;
        }
    }
}
