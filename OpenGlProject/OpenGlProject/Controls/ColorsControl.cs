using System.Windows.Forms;

namespace OpenGlProject.Controls
{
    /// <summary>
    /// Paint color control with two colors
    /// </summary>
    public partial class ColorsControl : UserControl
    {
        public ColorsControl()
        {
            InitializeComponent();
            this.exchangeBtn.Click += ExchangeClick;
        }

        public ColorControl MainColor => pictureBox1;
        /// <summary>
        /// Second color
        /// </summary>
        public ColorControl ExtendColor => pictureBox2;

        /// <summary>
        /// Swap colors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExchangeClick(object sender, System.EventArgs e)
        {
            var tmp = this.pictureBox1.ColorEditor;
            this.pictureBox1.ColorEditor = this.pictureBox2.ColorEditor;
            this.pictureBox2.ColorEditor = tmp;
        }
    }
}
