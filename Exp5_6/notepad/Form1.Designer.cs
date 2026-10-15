namespace notepad
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            文件FToolStripMenuItem = new ToolStripMenuItem();
            新建NToolStripMenuItem = new ToolStripMenuItem();
            打开OToolStripMenuItem = new ToolStripMenuItem();
            保存SToolStripMenuItem = new ToolStripMenuItem();
            退出XToolStripMenuItem = new ToolStripMenuItem();
            格式OToolStripMenuItem = new ToolStripMenuItem();
            加粗ToolStripMenuItem = new ToolStripMenuItem();
            斜体ToolStripMenuItem = new ToolStripMenuItem();
            下划线ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            字体ToolStripMenuItem = new ToolStripMenuItem();
            颜色ToolStripMenuItem = new ToolStripMenuItem();
            richTextBox1 = new RichTextBox();
            panel1 = new Panel();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 文件FToolStripMenuItem, 格式OToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(978, 32);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            文件FToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 新建NToolStripMenuItem, 打开OToolStripMenuItem, 保存SToolStripMenuItem, 退出XToolStripMenuItem });
            文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            文件FToolStripMenuItem.Size = new Size(84, 28);
            文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 新建NToolStripMenuItem
            // 
            新建NToolStripMenuItem.Name = "新建NToolStripMenuItem";
            新建NToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            新建NToolStripMenuItem.Size = new Size(270, 34);
            新建NToolStripMenuItem.Text = "新建";
            新建NToolStripMenuItem.Click += 新建NToolStripMenuItem_Click;
            // 
            // 打开OToolStripMenuItem
            // 
            打开OToolStripMenuItem.Name = "打开OToolStripMenuItem";
            打开OToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            打开OToolStripMenuItem.Size = new Size(270, 34);
            打开OToolStripMenuItem.Text = "打开";
            打开OToolStripMenuItem.Click += 打开OToolStripMenuItem_Click;
            // 
            // 保存SToolStripMenuItem
            // 
            保存SToolStripMenuItem.Name = "保存SToolStripMenuItem";
            保存SToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            保存SToolStripMenuItem.Size = new Size(270, 34);
            保存SToolStripMenuItem.Text = "保存";
            保存SToolStripMenuItem.Click += 保存SToolStripMenuItem_Click;
            // 
            // 退出XToolStripMenuItem
            // 
            退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            退出XToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            退出XToolStripMenuItem.Size = new Size(270, 34);
            退出XToolStripMenuItem.Text = "退出";
            退出XToolStripMenuItem.Click += 退出XToolStripMenuItem_Click;
            // 
            // 格式OToolStripMenuItem
            // 
            格式OToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 加粗ToolStripMenuItem, 斜体ToolStripMenuItem, 下划线ToolStripMenuItem, toolStripMenuItem1, 字体ToolStripMenuItem, 颜色ToolStripMenuItem });
            格式OToolStripMenuItem.Name = "格式OToolStripMenuItem";
            格式OToolStripMenuItem.Size = new Size(89, 28);
            格式OToolStripMenuItem.Text = "格式(&O)";
            // 
            // 加粗ToolStripMenuItem
            // 
            加粗ToolStripMenuItem.Name = "加粗ToolStripMenuItem";
            加粗ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.B;
            加粗ToolStripMenuItem.Size = new Size(270, 34);
            加粗ToolStripMenuItem.Text = "加粗";
            加粗ToolStripMenuItem.Click += 加粗ToolStripMenuItem_Click;
            // 
            // 斜体ToolStripMenuItem
            // 
            斜体ToolStripMenuItem.Name = "斜体ToolStripMenuItem";
            斜体ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            斜体ToolStripMenuItem.Size = new Size(270, 34);
            斜体ToolStripMenuItem.Text = "斜体";
            斜体ToolStripMenuItem.Click += 斜体ToolStripMenuItem_Click;
            // 
            // 下划线ToolStripMenuItem
            // 
            下划线ToolStripMenuItem.Name = "下划线ToolStripMenuItem";
            下划线ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.U;
            下划线ToolStripMenuItem.Size = new Size(270, 34);
            下划线ToolStripMenuItem.Text = "下划线";
            下划线ToolStripMenuItem.Click += 下划线ToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(267, 6);
            // 
            // 字体ToolStripMenuItem
            // 
            字体ToolStripMenuItem.Name = "字体ToolStripMenuItem";
            字体ToolStripMenuItem.Size = new Size(270, 34);
            字体ToolStripMenuItem.Text = "字体";
            字体ToolStripMenuItem.Click += 字体ToolStripMenuItem_Click;
            // 
            // 颜色ToolStripMenuItem
            // 
            颜色ToolStripMenuItem.Name = "颜色ToolStripMenuItem";
            颜色ToolStripMenuItem.Size = new Size(270, 34);
            颜色ToolStripMenuItem.Text = "颜色";
            颜色ToolStripMenuItem.Click += 颜色ToolStripMenuItem_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.White;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            richTextBox1.ForeColor = Color.FromArgb(51, 51, 51);
            richTextBox1.Location = new Point(60, 60);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(858, 492);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            richTextBox1.SelectionChanged += richTextBox1_SelectionChanged;
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(richTextBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(0, 32);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(60);
            panel1.Size = new Size(978, 612);
            panel1.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 644);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(600, 600);
            Name = "Form1";
            Text = "写字板";
            FormClosing += Form1_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 文件FToolStripMenuItem;
        private ToolStripMenuItem 新建NToolStripMenuItem;
        private ToolStripMenuItem 打开OToolStripMenuItem;
        private ToolStripMenuItem 保存SToolStripMenuItem;
        private ToolStripMenuItem 退出XToolStripMenuItem;
        private RichTextBox richTextBox1;
        private Panel panel1;
        private ToolStripMenuItem 格式OToolStripMenuItem;
        private ToolStripMenuItem 加粗ToolStripMenuItem;
        private ToolStripMenuItem 斜体ToolStripMenuItem;
        private ToolStripMenuItem 下划线ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem 字体ToolStripMenuItem;
        private ToolStripMenuItem 颜色ToolStripMenuItem;
    }
}
