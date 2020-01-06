namespace OpenGlProject.Controls
{
    partial class ColorsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.exchangeBtn = new System.Windows.Forms.Label();
            this.pictureBox1 = new OpenGlProject.Controls.ColorControl();
            this.pictureBox2 = new OpenGlProject.Controls.ColorControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.exchangeBtn.AutoSize = true;
            this.exchangeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exchangeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exchangeBtn.ForeColor = System.Drawing.Color.Blue;
            this.exchangeBtn.Location = new System.Drawing.Point(14, 75);
            this.exchangeBtn.Name = "label1";
            this.exchangeBtn.Size = new System.Drawing.Size(51, 13);
            this.exchangeBtn.TabIndex = 2;
            this.exchangeBtn.Text = "Сменить";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.ColorEditor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.ColorEditor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(33, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(52, 50);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // ColorsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exchangeBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "ColorsControl";
            this.Size = new System.Drawing.Size(89, 96);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ColorControl pictureBox1;
        private ColorControl pictureBox2;
        private System.Windows.Forms.Label exchangeBtn;
    }
}
