using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenGlProject.Controls
{
    /// <summary>
    /// Extend of Picture Box
    /// </summary>
    public class ColorControl : PictureBox
    {
        /// <summary>
        /// Dialog for choose color
        /// </summary>
        readonly ColorDialog colorDialog = new ColorDialog();
        /// <summary>
        /// 
        /// </summary>
        Color currentColor;

        public ColorControl()
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Current color
        /// </summary>
        public Color ColorEditor
        {
            get => currentColor;
            set
            {
                currentColor = value;
                RePaint();
            }
        }

        /// <summary>
        /// Repaint color in picture box
        /// </summary>
        private void RePaint() => BackColor = currentColor;

        /// <summary>
        /// Open colorDialog on click
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            var res = colorDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                currentColor = colorDialog.Color;
                RePaint();
            }
        }
    }
}
