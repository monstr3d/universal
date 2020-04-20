using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CommonControls.Interfaces
{
    /// <summary>
    /// ��������� �������, ������� ����� ���� ���������
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// ��������� �������
        /// </summary>
        /// <param name="g">�������� ����������</param>
        /// <param name="r">������������� ���������</param>
        void Draw(Graphics g, Rectangle r);
    }
}
