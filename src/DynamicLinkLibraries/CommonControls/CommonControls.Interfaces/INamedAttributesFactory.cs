using System;
using System.Collections.Generic;
using System.Text;

namespace CommonControls.Interfaces
{
    /// <summary>
    /// ������� ������� ������������ �� ������
    /// </summary>
    public interface INamedAttributesFactory
    {
        /// <summary>
        /// ������ �� ���������
        /// </summary>
        INamedAttributes Default
        {
            get;
        }

        /// <summary>
        /// ���������� ������ � �������� Id
        /// </summary>
        /// <param name="id">Id �������</param>
        /// <returns></returns>
        INamedAttributes this[object id]
        {
            get;
        }

    }
}
