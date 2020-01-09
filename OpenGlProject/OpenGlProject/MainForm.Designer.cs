using SharpGL;

namespace OpenGlProject
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рисованиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кистьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.карандашToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ластикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.слоиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инвертироватьЦветаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.увеличитьРезкостьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.brushBtn = new System.Windows.Forms.RadioButton();
            this.pencilBtn = new System.Windows.Forms.RadioButton();
            this.imageBtn = new System.Windows.Forms.RadioButton();
            this.eraserBtn = new System.Windows.Forms.RadioButton();
            this.signBtn = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.layoutsList = new System.Windows.Forms.CheckedListBox();
            this.colorsControl = new OpenGlProject.Controls.ColorsControl();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openGLControl = new SharpGL.OpenGLControl();
            this.splineBtn = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.рисованиеToolStripMenuItem,
            this.слоиToolStripMenuItem,
            this.фильтрыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // рисованиеToolStripMenuItem
            // 
            this.рисованиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.кистьToolStripMenuItem,
            this.карандашToolStripMenuItem,
            this.изображениеToolStripMenuItem,
            this.ластикToolStripMenuItem,
            this.подписьToolStripMenuItem});
            this.рисованиеToolStripMenuItem.Name = "рисованиеToolStripMenuItem";
            this.рисованиеToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.рисованиеToolStripMenuItem.Text = "Рисование";
            // 
            // кистьToolStripMenuItem
            // 
            this.кистьToolStripMenuItem.Name = "кистьToolStripMenuItem";
            this.кистьToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.кистьToolStripMenuItem.Text = "Кисть";
            this.кистьToolStripMenuItem.Click += new System.EventHandler(this.BrushMenu);
            // 
            // карандашToolStripMenuItem
            // 
            this.карандашToolStripMenuItem.Name = "карандашToolStripMenuItem";
            this.карандашToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.карандашToolStripMenuItem.Text = "Карандаш";
            this.карандашToolStripMenuItem.Click += new System.EventHandler(this.PencilMenu);
            // 
            // изображениеToolStripMenuItem
            // 
            this.изображениеToolStripMenuItem.Name = "изображениеToolStripMenuItem";
            this.изображениеToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.изображениеToolStripMenuItem.Text = "Изображение";
            this.изображениеToolStripMenuItem.Click += new System.EventHandler(this.ImageMenu);
            // 
            // ластикToolStripMenuItem
            // 
            this.ластикToolStripMenuItem.Name = "ластикToolStripMenuItem";
            this.ластикToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.ластикToolStripMenuItem.Text = "Ластик";
            this.ластикToolStripMenuItem.Click += new System.EventHandler(this.EraserMenu);
            // 
            // подписьToolStripMenuItem
            // 
            this.подписьToolStripMenuItem.Name = "подписьToolStripMenuItem";
            this.подписьToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.подписьToolStripMenuItem.Text = "Подпись";
            this.подписьToolStripMenuItem.Click += new System.EventHandler(this.SignMenu);
            // 
            // слоиToolStripMenuItem
            // 
            this.слоиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.слоиToolStripMenuItem.Name = "слоиToolStripMenuItem";
            this.слоиToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.слоиToolStripMenuItem.Text = "Слои";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.AddLayoutMenu);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.RemoveLayoutMenu);
            // 
            // фильтрыToolStripMenuItem
            // 
            this.фильтрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.инвертироватьЦветаToolStripMenuItem,
            this.увеличитьРезкостьToolStripMenuItem});
            this.фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            this.фильтрыToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.фильтрыToolStripMenuItem.Text = "Фильтры";
            // 
            // инвертироватьЦветаToolStripMenuItem
            // 
            this.инвертироватьЦветаToolStripMenuItem.Name = "инвертироватьЦветаToolStripMenuItem";
            this.инвертироватьЦветаToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.инвертироватьЦветаToolStripMenuItem.Text = "Инвертировать цвета";
            this.инвертироватьЦветаToolStripMenuItem.Click += new System.EventHandler(this.InvertFilterMenu);
            // 
            // увеличитьРезкостьToolStripMenuItem
            // 
            this.увеличитьРезкостьToolStripMenuItem.Name = "увеличитьРезкостьToolStripMenuItem";
            this.увеличитьРезкостьToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.увеличитьРезкостьToolStripMenuItem.Text = "Увеличить резкость";
            this.увеличитьРезкостьToolStripMenuItem.Click += new System.EventHandler(this.SharpnessFilterMenu);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.brushBtn);
            this.flowLayoutPanel1.Controls.Add(this.pencilBtn);
            this.flowLayoutPanel1.Controls.Add(this.imageBtn);
            this.flowLayoutPanel1.Controls.Add(this.eraserBtn);
            this.flowLayoutPanel1.Controls.Add(this.signBtn);
            this.flowLayoutPanel1.Controls.Add(this.splineBtn);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(54, 550);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // brushBtn
            // 
            this.brushBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.brushBtn.BackgroundImage = global::OpenGlProject.Properties.Resources.brush;
            this.brushBtn.Location = new System.Drawing.Point(3, 3);
            this.brushBtn.Name = "brushBtn";
            this.brushBtn.Size = new System.Drawing.Size(48, 48);
            this.brushBtn.TabIndex = 0;
            this.brushBtn.UseVisualStyleBackColor = true;
            this.brushBtn.CheckedChanged += new System.EventHandler(this.BrushBtnCheckedChanged);
            // 
            // pencilBtn
            // 
            this.pencilBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.pencilBtn.BackgroundImage = global::OpenGlProject.Properties.Resources.grease_pencil;
            this.pencilBtn.Location = new System.Drawing.Point(3, 57);
            this.pencilBtn.Name = "pencilBtn";
            this.pencilBtn.Size = new System.Drawing.Size(48, 48);
            this.pencilBtn.TabIndex = 1;
            this.pencilBtn.UseVisualStyleBackColor = true;
            this.pencilBtn.CheckedChanged += new System.EventHandler(this.pencilBtn_CheckedChanged);
            // 
            // imageBtn
            // 
            this.imageBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.imageBtn.BackgroundImage = global::OpenGlProject.Properties.Resources.file_image_outline;
            this.imageBtn.Location = new System.Drawing.Point(3, 111);
            this.imageBtn.Name = "imageBtn";
            this.imageBtn.Size = new System.Drawing.Size(48, 48);
            this.imageBtn.TabIndex = 2;
            this.imageBtn.UseVisualStyleBackColor = true;
            this.imageBtn.CheckedChanged += new System.EventHandler(this.imageBtn_CheckedChanged);
            // 
            // eraserBtn
            // 
            this.eraserBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.eraserBtn.BackgroundImage = global::OpenGlProject.Properties.Resources.eraser;
            this.eraserBtn.Location = new System.Drawing.Point(3, 165);
            this.eraserBtn.Name = "eraserBtn";
            this.eraserBtn.Size = new System.Drawing.Size(48, 48);
            this.eraserBtn.TabIndex = 3;
            this.eraserBtn.UseVisualStyleBackColor = true;
            this.eraserBtn.CheckedChanged += new System.EventHandler(this.eraserBtn_CheckedChanged);
            // 
            // signBtn
            // 
            this.signBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.signBtn.BackgroundImage = global::OpenGlProject.Properties.Resources.clipboard_account_outline;
            this.signBtn.Location = new System.Drawing.Point(3, 219);
            this.signBtn.Name = "signBtn";
            this.signBtn.Size = new System.Drawing.Size(48, 48);
            this.signBtn.TabIndex = 4;
            this.signBtn.UseVisualStyleBackColor = true;
            this.signBtn.CheckedChanged += new System.EventHandler(this.signBtn_CheckedChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.button5);
            this.flowLayoutPanel2.Controls.Add(this.button7);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(746, 27);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(54, 550);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::OpenGlProject.Properties.Resources.plus_circle_outline;
            this.button5.Location = new System.Drawing.Point(3, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(48, 48);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.AddLayout);
            // 
            // button7
            // 
            this.button7.BackgroundImage = global::OpenGlProject.Properties.Resources.minus_circle_outline;
            this.button7.Location = new System.Drawing.Point(3, 57);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(48, 48);
            this.button7.TabIndex = 5;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.RemoveLayout);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.layoutsList);
            this.flowLayoutPanel3.Controls.Add(this.colorsControl);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(622, 27);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(118, 550);
            this.flowLayoutPanel3.TabIndex = 6;
            // 
            // layoutsList
            // 
            this.layoutsList.FormattingEnabled = true;
            this.layoutsList.Items.AddRange(new object[] {
            "Главный слой"});
            this.layoutsList.Location = new System.Drawing.Point(3, 3);
            this.layoutsList.Name = "layoutsList";
            this.layoutsList.Size = new System.Drawing.Size(112, 169);
            this.layoutsList.TabIndex = 1;
            // 
            // colorsControl
            // 
            this.colorsControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.colorsControl.Location = new System.Drawing.Point(3, 178);
            this.colorsControl.Name = "colorsControl";
            this.colorsControl.Size = new System.Drawing.Size(112, 97);
            this.colorsControl.TabIndex = 2;
            // 
            // openGLControl
            // 
            this.openGLControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.openGLControl.DrawFPS = false;
            this.openGLControl.Location = new System.Drawing.Point(60, 27);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(550, 550);
            this.openGLControl.TabIndex = 3;
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.OpenGLControl_OpenGLDraw);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseUp);
            // 
            // radioButton1
            // 
            this.splineBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.splineBtn.BackgroundImage = global::OpenGlProject.Properties.Resources.chart_areaspline;
            this.splineBtn.Location = new System.Drawing.Point(3, 273);
            this.splineBtn.Name = "radioButton1";
            this.splineBtn.Size = new System.Drawing.Size(48, 48);
            this.splineBtn.TabIndex = 5;
            this.splineBtn.UseVisualStyleBackColor = true;
            this.splineBtn.CheckedChanged += new System.EventHandler(this.SplineBtn_Checked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 584);
            this.Controls.Add(this.openGLControl);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рисованиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem слоиToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckedListBox layoutsList;
        private Controls.ColorsControl colorsControl;
        private OpenGLControl openGLControl;
        private System.Windows.Forms.RadioButton brushBtn;
        private System.Windows.Forms.RadioButton pencilBtn;
        private System.Windows.Forms.RadioButton imageBtn;
        private System.Windows.Forms.RadioButton eraserBtn;
        private System.Windows.Forms.RadioButton signBtn;
        private System.Windows.Forms.ToolStripMenuItem кистьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem карандашToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ластикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подписьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инвертироватьЦветаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem увеличитьРезкостьToolStripMenuItem;
        private System.Windows.Forms.RadioButton splineBtn;
    }
}

