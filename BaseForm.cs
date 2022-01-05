using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms6464
{
    public abstract class BaseForm 
        : Form
    {
        public BaseForm()
        {
            SuspendLayout();
            InitializeComponent();
            DecideOpacitySetting();
            ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                EnableOpacityGloballyChanged -= OnEnableOpacityGloballyChanged;
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.Font = SystemFonts.MenuFont;
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            EnableOpacityGloballyChanged += OnEnableOpacityGloballyChanged;
            DecideOpacitySetting();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            EnableOpacityGloballyChanged -= OnEnableOpacityGloballyChanged;
        }

        private static EventHandler? EnableOpacityGloballyChanged;
        private static void RaiseEnableOpacityGloballyChanged()
        {
            EnableOpacityGloballyChanged?.Invoke(null, EventArgs.Empty);
        }

        private static bool enableOpacityGlobally = true;
        public static bool EnableOpacityGlobally
        {
            get => enableOpacityGlobally;

            set
            {
                enableOpacityGlobally = value;
                RaiseEnableOpacityGloballyChanged();
            }
        }

        private void OnEnableOpacityGloballyChanged(object? sender, EventArgs e)
        {
            if (this.IsDisposed)
            {
                return;
            }

            if (this.InvokeRequired)
            {
                try
                {
                    BeginInvoke(() => OnEnableOpacityGloballyChanged(sender, e));
                }
                catch (Exception)
                {
                    // ignore
                }
            }
            else
            {
                DecideOpacitySetting();
            }
        }

        private bool enableOpacity = true;
        public bool EnableOpacity
        {
            get => this.enableOpacity;

            set
            {
                this.enableOpacity = value;
                DecideOpacitySetting();
            }
        }

        private void DecideOpacitySetting()
        {
            if (!EnableOpacityGlobally || !this.EnableOpacity)
            {
                if (this.enableOpacity && this.IsHandleCreatedOld)
                {
                    NativeHelper.SetFormOpacity(this, 255);
                }

                this.enableOpacity = false;
            }
            else
            {
                if (!this.EnableOpacity && this.IsHandleCreatedOld)
                {
                    NativeHelper.SetFormOpacity(this, DoubleUtil.ClampToByte((this.opacity * 255.0) + 0.5));
                }

                this.enableOpacity = true;
            }
        }

        private double opacity;
        public new double Opacity
        {
            get => this.opacity;

            set
            {
                if (this.enableOpacity && this.IsHandleCreatedOld)
                {
                    NativeHelper.SetFormOpacity(this, DoubleUtil.ClampToByte((value * 255.0) + 0.5));
                }

                this.opacity = value;
            }
        }

        // Called in places where I was _not_ calling it before. Change to 'return true;' to recreate the bug
        private bool IsHandleCreatedOld
        {
            // Everything works fine
            //get => this.IsHandleCreated;

            // All heck breaks loose
            get => true;
        }
    }
}
