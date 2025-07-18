using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.ComponentModel;

namespace OfficePickers.Util
{
    /// <summary>
    /// Enables you to group control in a panel with a gradient background.
    /// </summary>
    [ToolboxItem(true),
    Description("Enables you to group control in a panel with a gradient background."),
    ToolboxBitmap(typeof(GradientPanel), "GradientPanel")]
    public class GradientPanel : Panel
    {
        #region Properties

        private Color _startColor = Color.Black;
        /// <summary>
        /// Gets or sets the left/upper color for the gradient panel
        /// </summary>
        [Category("Appearance"), Description("The left/upper color for the gradient panel.")]

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color StartColor
        {
            get { return _startColor; }
            set { _startColor = value; this.Refresh(); }
        }

        private Color _endColor = Color.White;
        /// <summary>
        /// Gets or sets the right/lower color for the gradient panel
        /// </summary>
        [Category("Appearance"), Description("The right/lower color for the gradient panel.")]

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color EndColor
        {
            get { return _endColor; }
            set { _endColor = value; this.Refresh(); }
        }

        private LinearGradientMode _gradientMode = LinearGradientMode.BackwardDiagonal;

        /// <summary>
        /// Gets or sets the direction of the linear gradient
        /// </summary>
        [Category("Appearance"), Description("The direction of the linear gradient.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LinearGradientMode GradientMode
        {
            get { return _gradientMode; }
            set { _gradientMode = value; this.Refresh(); }
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public GradientPanel() : base()
        {
        }

        #endregion

        #region Paints overrides
        /// <summary>
        /// Paints the background in the gradient brush
        /// </summary>
        /// <param name="pevent">Event arguments</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            LinearGradientBrush brush = 
                new LinearGradientBrush(pevent.ClipRectangle, _startColor, _endColor,  _gradientMode);
            pevent.Graphics.FillRectangle(brush, pevent.ClipRectangle);
            brush.Dispose();
        }
        #endregion
    }
}
