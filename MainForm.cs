using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms6464
{
    public partial class MainForm : BaseForm
    {
        private Button button;

        public MainForm()
        {
            InitializeComponent();
        }

        [MemberNotNull(nameof(button))]
        private void InitializeComponent()
        {
            this.button = new Button();
            this.button.AutoSize = true;
            this.button.Text = "Click Me";
            this.button.Click += OnButtonClick;
            this.button.Location = new Point(32, 32);

            SuspendLayout();

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ResizeRedraw = true;
            this.StartPosition = FormStartPosition.WindowsDefaultBounds;
            this.Controls.Add(this.button);

            ResumeLayout(false);
        }

        private void OnButtonClick(object? sender, EventArgs e)
        {
            using (SecondForm form = new SecondForm())
            {
                form.ShowDialog(this);
            }
        }
    }
}
