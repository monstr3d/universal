using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace CommonControls.Interfaces
{
    /// <summary>
    /// �������������� ��������, ���������������
    /// ��� ������������ �������� ���������������� ����������
    /// </summary>
    public interface ISerializableControl
    {
        /// <summary>
        /// �������� ������� ������� ����� ���� ������������
        /// � ���� ����������� �����
        /// </summary>
        Dictionary<string, string> Properties
        {
            get;
            set;
        }

        /// <summary>
        /// �������� �������� ����������������� ����������.
        /// </summary>
        List<ISerializable> Controls
        {
            get;
            set;
        }

        /// <summary>
        /// �������� �������, ���������� �������������� ���������.
        /// </summary>
        Dictionary<string, ISerializable> Other
        {
            get;
            set;
        }
    }
}
