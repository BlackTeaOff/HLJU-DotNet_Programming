using System.Windows.Forms.Design;

namespace notepad
{
    public partial class Form1 : Form
    {
        private string currentFilePath = null;

        public Form1()
        {
            InitializeComponent();

            menuStrip1.Renderer = new ModernMenuRenderer();

            menuStrip1.Font = new Font("Microsoft YaHei UI", 9F);

            // ToolStripMenuItem 是菜单项
            // menuStrip1 是整个菜单, 里面的 Items 保存各个菜单项
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                // DropDown 是这个菜单项里面整个下拉栏(ToolStripDropDownMenu)
                // ToolStripDropDownMenu 是一个容器, 里面有其他 Item
                if (item.DropDown is ToolStripDropDownMenu dropDown)
                {
                    dropDown.ShowImageMargin = false;
                    if (item.Text.Contains("格式"))
                    {
                        dropDown.ShowCheckMargin = true;
                    }
                    else
                    {
                        dropDown.ShowCheckMargin = false;
                    }


                    // 在 DropDown 里面有组成这个下拉栏的每一行(ToolStripItem)
                    //foreach (ToolStripItem subItem in dropDown.Items)
                    //{
                    //    subItem.Padding = new Padding(15, 5, 15, 5);
                    //}
                }
            }
        }

        private bool PromptSaveIfModified()
        {
            if (!richTextBox1.Modified) return true;

            DialogResult result = MessageBox.Show(
                "是否保存更改？\n如果不保存, 您的更改将会丢失。",
                "保存",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                保存SToolStripMenuItem_Click(null, null);
                // 如果在窗口点了取消, 那 Modified 还是返回 True
                // 仍然向调用者返回 false 表示不能清空
                return !richTextBox1.Modified;
            }
            else if (result == DialogResult.No)
            {
                return true;
            }
            else // cancal
            {
                return false;
            }
        }

        private void UpdateTitle()
        {
            string fileName = string.IsNullOrEmpty(currentFilePath) ? "无标题" : System.IO.Path.GetFileName(currentFilePath);

            string mark = richTextBox1.Modified ? "*" : "";

            // title
            this.Text = $"{fileName}{mark} - 写字板";
        }

        // currentFilePath 不为空的时候可以直接保存
        // 为空的时候需要在窗口选路径
        // 这两种方式都共用这个函数, 只需要知道存哪里就行
        private void SaveToFile(string path)
        {
            if (path.EndsWith(".rtf", StringComparison.OrdinalIgnoreCase))
            {
                richTextBox1.SaveFile(path, RichTextBoxStreamType.RichText);
            }
            else
            {
                richTextBox1.SaveFile(path, RichTextBoxStreamType.PlainText);
            }

            currentFilePath = path;
            richTextBox1.Modified = false;
            UpdateTitle();
        }

        private void 新建NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PromptSaveIfModified()) return;

            richTextBox1.Clear();
            richTextBox1.Modified = false;
            currentFilePath = null;
            UpdateTitle();
            /*
            // 用静态方法防止 Text 为空
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                // 内容, 标题, 按钮, 图标
                DialogResult result = MessageBox.Show("是否新建？当前内容将被清空！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;

                richTextBox1.Clear();
            }
            */
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFilePath != null)
            {
                SaveToFile(currentFilePath);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "保存文件";
                sfd.Filter = "富文本格式(*.rtf)|*.rtf|文本文档(*.txt)|*.txt";
                sfd.FileName = "untitled.rtf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    SaveToFile(sfd.FileName);
                    /*
                    if (sfd.FilterIndex == 1)
                    {
                        richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
                    }

                    richTextBox1.Modified = false;
                    currentFilePath = sfd.FileName;
                    UpdateTitle();
                    MessageBox.Show("文件保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    */
                }
            }
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PromptSaveIfModified()) return;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "打开文件";
                ofd.Filter = "富文本格式(*.rtf)|*.rtf|文本文档(*.txt)|*.txt";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (ofd.FileName.EndsWith(".rtf", StringComparison.OrdinalIgnoreCase))
                    {
                        richTextBox1.LoadFile(ofd.FileName, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        richTextBox1.LoadFile(ofd.FileName, RichTextBoxStreamType.PlainText);
                    }

                    // 改为未修改状态
                    richTextBox1.Modified = false;
                    currentFilePath = ofd.FileName;
                    UpdateTitle();
                }
            }
        }

        // sender 是点击那个菜单项实例本身
        // 用 Object 保证所有对象都能传入
        // 两个地方的加粗按钮(菜单项或者按钮)可以传入同一个函数
        // e 是点击事件传入的信息(点击基本没啥可传的)
        private void 加粗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Bold);
            加粗ToolStripMenuItem.Checked = richTextBox1.SelectionFont != null ? richTextBox1.SelectionFont.Bold : false;
        }

        private void 斜体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Italic);
            斜体ToolStripMenuItem.Checked = richTextBox1.SelectionFont != null ? richTextBox1.SelectionFont.Italic : false;
        }

        private void 下划线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Underline);
            下划线ToolStripMenuItem.Checked = richTextBox1.SelectionFont != null ? richTextBox1.SelectionFont.Underline : false;
        }

        // 改变字样式的函数, 传入枚举类型 FontStyle
        private void ToggleFontStyle(FontStyle style)
        {
            if (richTextBox1.SelectionLength == 0)
            {
                return;
            }

            // 如果用户选中多种不同的字体
            // 会返回空
            Font currentFont = richTextBox1.SelectionFont == null ? richTextBox1.Font : richTextBox1.SelectionFont;
            if (currentFont != null)
            {
                // 异或得到新字体样式(相同等于0, 不同等于1)
                FontStyle newStyle = currentFont.Style ^ style;

                // Font 对象内部属性只读, 必须 new 一个 Font
                richTextBox1.SelectionFont = new Font(currentFont, newStyle);
            }
        }


        // 选了其他字, 或者光标移动触发
        // 改变菜单栏状态(加粗什么的)
        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            // 获取光标所在位置字体(为空就设为默认字体)
            Font currentFont = richTextBox1.SelectionFont ?? richTextBox1.Font;

            加粗ToolStripMenuItem.Checked = currentFont.Bold;
            斜体ToolStripMenuItem.Checked = currentFont.Italic;
            下划线ToolStripMenuItem.Checked = currentFont.Underline;
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // using 相当于 try-with-resources, 自动释放资源
            using (FontDialog fontDialog = new FontDialog())
            {
                fontDialog.Font = richTextBox1.SelectionFont ?? richTextBox1.Font;

                // 打开窗口
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectionFont = fontDialog.Font;
                }
            }
        }

        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // 默认返回第一个选中文字的颜色, 不会为空
                colorDialog.Color = richTextBox1.SelectionColor;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectionColor = colorDialog.Color;
                }
            }
        }

        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!PromptSaveIfModified())
            {
                e.Cancel = true;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateTitle();
        }
    }

    public class ModernMenuRenderer : ToolStripProfessionalRenderer
    {
        // e 是当前要渲染的事件
        // 在给父类的 OnRenderItemText 之前先修改渲染事件
        // 里面包括要渲染什么(e.Text), 渲染哪个类的实例(e.Item)
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            // is 判断是不是菜单项, 然后把这个 Item 赋给 item
            // 只有菜单项才有 IsOnDropDown 属性
            // IsOnDropDown 判断是不是菜单项的下拉栏, 因为不能改变菜单项本身
            if (e.Item is ToolStripMenuItem item && item.IsOnDropDown)
            {
                // 如果画的文字和 item.Text 不一样，说明当前画的是快捷键
                if (e.Text != item.Text)
                {
                    e.TextColor = Color.FromArgb(140, 140, 140); // 快捷键使用低调的浅灰色（Typora风格）
                    e.TextFont = new Font("Segoe UI", 9f, FontStyle.Regular); // 快捷键使用普通字体
                }
                else // 当前画的是操作名字
                {
                    e.TextColor = Color.White; // 操作字使用高亮纯白色
                }
            }

            // 把改好的 e 给父类的函数去渲染
            base.OnRenderItemText(e);
        }
    }
}
