namespace EditorOpenGl
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.objectsComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.oxScroll = new System.Windows.Forms.TrackBar();
            this.zoomScroll = new System.Windows.Forms.TrackBar();
            this.angleScroll = new System.Windows.Forms.TrackBar();
            this.ozScroll = new System.Windows.Forms.TrackBar();
            this.oyScroll = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.openGLControl = new SharpGL.OpenGLControl();
            ((System.ComponentModel.ISupportInitialize)(this.oxScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ozScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oyScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(661, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "По оси";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(662, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(163, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // objectsComboBox
            // 
            this.objectsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectsComboBox.FormattingEnabled = true;
            this.objectsComboBox.Location = new System.Drawing.Point(661, 80);
            this.objectsComboBox.Name = "objectsComboBox";
            this.objectsComboBox.Size = new System.Drawing.Size(164, 21);
            this.objectsComboBox.TabIndex = 4;
            this.objectsComboBox.SelectedIndexChanged += new System.EventHandler(this.objectsComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(660, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Объект";
            // 
            // checkBox1
            // 
            this.checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(661, 108);
            this.checkBox.Name = "checkBox1";
            this.checkBox.Size = new System.Drawing.Size(75, 17);
            this.checkBox.TabIndex = 5;
            this.checkBox.Text = "Сеточный";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // oxScroll
            // 
            this.oxScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oxScroll.LargeChange = 1;
            this.oxScroll.Location = new System.Drawing.Point(661, 164);
            this.oxScroll.Maximum = 359;
            this.oxScroll.Name = "oxScroll";
            this.oxScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.oxScroll.Size = new System.Drawing.Size(45, 294);
            this.oxScroll.TabIndex = 6;
            this.oxScroll.Scroll += new System.EventHandler(this.OxScrollChanged);
            // 
            // zoomScroll
            // 
            this.zoomScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomScroll.LargeChange = 1;
            this.zoomScroll.Location = new System.Drawing.Point(865, 164);
            this.zoomScroll.Minimum = -10;
            this.zoomScroll.Name = "zoomScroll";
            this.zoomScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.zoomScroll.Size = new System.Drawing.Size(45, 294);
            this.zoomScroll.TabIndex = 7;
            this.zoomScroll.Scroll += new System.EventHandler(this.zoomScroll_Scroll);
            // 
            // angleScroll
            // 
            this.angleScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.angleScroll.LargeChange = 1;
            this.angleScroll.Location = new System.Drawing.Point(814, 164);
            this.angleScroll.Maximum = 359;
            this.angleScroll.Name = "angleScroll";
            this.angleScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.angleScroll.Size = new System.Drawing.Size(45, 294);
            this.angleScroll.TabIndex = 8;
            // 
            // ozScroll
            // 
            this.ozScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ozScroll.LargeChange = 1;
            this.ozScroll.Location = new System.Drawing.Point(763, 164);
            this.ozScroll.Maximum = 359;
            this.ozScroll.Name = "ozScroll";
            this.ozScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ozScroll.Size = new System.Drawing.Size(45, 294);
            this.ozScroll.TabIndex = 9;
            this.ozScroll.Scroll += new System.EventHandler(this.ozScroll_Scroll);
            // 
            // oyScroll
            // 
            this.oyScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oyScroll.LargeChange = 1;
            this.oyScroll.Location = new System.Drawing.Point(712, 164);
            this.oyScroll.Maximum = 359;
            this.oyScroll.Name = "oyScroll";
            this.oyScroll.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.oyScroll.Size = new System.Drawing.Size(45, 294);
            this.oyScroll.TabIndex = 10;
            this.oyScroll.Scroll += new System.EventHandler(this.OyScrollChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(862, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Zoom";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(811, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Angle";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(754, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Z";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(706, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Y";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(658, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "X";
            // 
            // openGLControl
            // 
            this.openGLControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openGLControl.DrawFPS = false;
            this.openGLControl.Location = new System.Drawing.Point(12, 12);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(643, 457);
            this.openGLControl.TabIndex = 0;
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
            this.Controls.Add(this.objectsComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.openGLControl);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.oxScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ozScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oyScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox objectsComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.TrackBar oxScroll;
        private System.Windows.Forms.TrackBar zoomScroll;
        private System.Windows.Forms.TrackBar angleScroll;
        private System.Windows.Forms.TrackBar ozScroll;
        private System.Windows.Forms.TrackBar oyScroll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private SharpGL.OpenGLControl openGLControl;
    }
}

