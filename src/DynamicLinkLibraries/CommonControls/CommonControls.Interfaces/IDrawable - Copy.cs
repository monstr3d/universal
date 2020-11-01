using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CommonControls.Interfaces
{
    /// <summary>
    /// Интерфейс объекта, который может быть отрисован
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// Рисование объекта
        /// </summary>
        /// <param name="g">Контекст устройства</param>
        /// <param name="r">Прямоугольник отрисовки</param>
        void Draw(Graphics g, Rectangle r);
    }
}
