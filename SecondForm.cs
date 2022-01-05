using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms6464
{
    public sealed class SecondForm
        : BaseForm
    {
        public SecondForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            this.Controls.AddRange(
                new Control[]
                {
                    new Button() { AutoSize = true, Text = "Button 1", Location = new Point(32, 32) },
                    new Button() { AutoSize = true, Text = "Button 2", Location = new Point(32, 72) },
                    new Label() { AutoSize = true, Text = "This is a label", Location = new Point(32, 112) }
                });

            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.StartPosition = FormStartPosition.CenterParent;

            ResumeLayout(false);
        }
    }
}
