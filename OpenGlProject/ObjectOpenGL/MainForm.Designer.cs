namespace ObjectOpenGL
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.oyScroll = new System.Windows.Forms.TrackBar();
            this.ozScroll = new System.Windows.Forms.TrackBar();
            this.angleScroll = new System.Windows.Forms.TrackBar();
            this.zoomScroll = new System.Windows.Forms.TrackBar();
            this.oxScroll = new System.Windows.Forms.TrackBar();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.rotateComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openGLControl = new SharpGL.OpenGLControl();
            ((System.ComponentModel.ISupportInitialize)(this.oyScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ozScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oxScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(671, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "X";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(719, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Y";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(767, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Z";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(824, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Angle";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(875, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Zoom";
            // 
            // oyScroll
            // 
            this.oyScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oyScroll.LargeChange = 1;
            this.oyScroll.Location = new System.Drawing.Point(725, 164);
            this.oyScroll.Maximum = 359;
            this.oyScroll.Name = "oyScroll";
            this.oyScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.oyScroll.Size = new System.Drawing.Size(45, 294);
            this.oyScroll.TabIndex = 26;
            this.oyScroll.Scroll += new System.EventHandler(this.OyScrollChanged);
            // 
            // ozScroll
            // 
            this.ozScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ozScroll.LargeChange = 1;
            this.ozScroll.Location = new System.Drawing.Point(776, 164);
            this.ozScroll.Maximum = 359;
            this.ozScroll.Name = "ozScroll";
            this.ozScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ozScroll.Size = new System.Drawing.Size(45, 294);
            this.ozScroll.TabIndex = 25;
            this.ozScroll.Scroll += new System.EventHandler(this.ozScroll_Scroll);
            // 
            // angleScroll
            // 
            this.angleScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.angleScroll.LargeChange = 1;
            this.angleScroll.Location = new System.Drawing.Point(827, 164);
            this.angleScroll.Maximum = 359;
            this.angleScroll.Name = "angleScroll";
            this.angleScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.angleScroll.Size = new System.Drawing.Size(45, 294);
            this.angleScroll.TabIndex = 24;
            this.angleScroll.Scroll += new System.EventHandler(this.angleScroll_Scroll);
            // 
            // zoomScroll
            // 
            this.zoomScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomScroll.LargeChange = 1;
            this.zoomScroll.Location = new System.Drawing.Point(878, 164);
            this.zoomScroll.Minimum = -10;
            this.zoomScroll.Name = "zoomScroll";
            this.zoomScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.zoomScroll.Size = new System.Drawing.Size(45, 294);
            this.zoomScroll.TabIndex = 23;
            this.zoomScroll.Scroll += new System.EventHandler(this.zoomScroll_Scroll);
            // 
            // oxScroll
            // 
            this.oxScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oxScroll.LargeChange = 1;
            this.oxScroll.Location = new System.Drawing.Point(674, 164);
            this.oxScroll.Maximum = 359;
            this.oxScroll.Name = "oxScroll";
            this.oxScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.oxScroll.Size = new System.Drawing.Size(45, 294);
            this.oxScroll.TabIndex = 22;
            this.oxScroll.Scroll += new System.EventHandler(this.OxScrollChanged);
            // 
            // checkBox
            // 
            this.checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(674, 108);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(75, 17);
            this.checkBox.TabIndex = 21;
            this.checkBox.Text = "Сеточный";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // rotateComboBox
            // 
            this.rotateComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rotateComboBox.FormattingEnabled = true;
            this.rotateComboBox.Items.AddRange(new object[] {
            "Вращать вдоль Ox",
            "Вращать вдоль Oy",
            "Вращать вдоль Oz"});
            this.rotateComboBox.Location = new System.Drawing.Point(674, 50);
            this.rotateComboBox.Name = "rotateComboBox";
            this.rotateComboBox.Size = new System.Drawing.Size(163, 21);
            this.rotateComboBox.TabIndex = 18;
            this.rotateComboBox.SelectedIndexChanged += new System.EventHandler(this.rotateComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(674, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "По оси";
            // 
            // openGLControl
            // 
            this.openGLControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openGLControl.DrawFPS = false;
            this.openGLControl.Location = new System.Drawing.Point(25, 12);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(643, 457);
            this.openGLControl.TabIndex = 16;
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl1_OpenGLDraw);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 481);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.oyScroll);
            this.Controls.Add(this.ozScroll);
            this.Controls.Add(this.angleScroll);
            this.Controls.Add(this.zoomScroll);
            this.Controls.Add(this.oxScroll);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.rotateComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.openGLControl);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.oyScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ozScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oxScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar oyScroll;
        private System.Windows.Forms.TrackBar ozScroll;
        private System.Windows.Forms.TrackBar angleScroll;
        private System.Windows.Forms.TrackBar zoomScroll;
        private System.Windows.Forms.TrackBar oxScroll;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.ComboBox rotateComboBox;
        private System.Windows.Forms.Label label1;
        private SharpGL.OpenGLControl openGLControl;
    }
}

