using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TerraFX.Interop.Windows;

using static TerraFX.Interop.Windows.GWL;
using static TerraFX.Interop.Windows.LWA;
using static TerraFX.Interop.Windows.Windows;
using static TerraFX.Interop.Windows.WS;

namespace WinForms6464
{
    internal static class NativeHelper
    {
        public static unsafe void SetFormOpacity(Form form, byte opacity)
        {
            HWND hwnd = (HWND)form.Handle;

            //uint exStyle = (uint)NativeMethods.GetWindowLongPtrW(form.Handle, NativeConstants.GWL_EXSTYLE);
            nint exStyle = GetWindowLongPtrW(hwnd, GWL_EXSTYLE);

            byte bOldAlpha = 255;
            if ((exStyle & GWL_EXSTYLE) != 0)
            {
                COLORREF dwOldKey;
                uint dwOldFlags;
                GetLayeredWindowAttributes(hwnd, &dwOldKey, &bOldAlpha, &dwOldFlags);
            }

            byte bNewAlpha = opacity;
            nint newExStyle = exStyle;

            if (bNewAlpha != 255)
            {
                newExStyle |= WS_EX_LAYERED;
            }

            if (newExStyle != exStyle || (newExStyle & WS_EX_LAYERED) != 0)
            {
                if (newExStyle != exStyle)
                {
                    SetWindowLongPtrW(hwnd, GWL_EXSTYLE, newExStyle);
                }

                if ((newExStyle & WS_EX_LAYERED) != 0)
                {
                    SetLayeredWindowAttributes(hwnd, 0, bNewAlpha, LWA_ALPHA);
                }
            }

            GC.KeepAlive(form);
        }
    }
}
