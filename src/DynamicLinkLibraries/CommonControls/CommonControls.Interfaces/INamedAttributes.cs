using System;
using System.Collections.Generic;
using System.Text;

namespace CommonControls.Interfaces
{
    /// <summary>
    /// ������, ������� ����������� ��������
    /// </summary>
    public interface INamedAttributes
    {
        /// <summary>
        /// ���������� �������
        /// </summary>
        /// <param name="name">��� ��������</param>
        /// <returns>�������</returns>
        object this[string name]
        {
            get;
        }

        /// <summary>
        /// ����� ���� ���������
        /// </summary>
        string[] Names
        {
            get;
        }

        /// <summary>
        /// ���������� ��� ������������ �� ������
        /// </summary>
        /// <param name="name">��� �������</param>
        /// <returns>��� ������������ �� ������</returns>
        string GetDisplayName(string name);

        /// <summary>
        /// ������ �� ���������
        /// </summary>
        /// <param name="name">��� �������</param>
        /// <returns>������ �� ���������</returns>
        object GetDefaultObject(string name);

    }
}
