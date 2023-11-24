using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace WpfApp1
{
    public class ControlHost : HwndHost
    {
        IntPtr hwndControl;
        IntPtr hwndHost;
        int hostHeight, hostWidth;

        public ControlHost()
        {
            hostHeight = 0;
            hostWidth = 0;
        }
        protected override HandleRef BuildWindowCore(HandleRef hwndParent)
        {
            hwndHost = CreateWindowCore(hostWidth, hostHeight, hwndParent.Handle);
            return new HandleRef(this, hwndHost);
        }
        protected override void DestroyWindowCore(HandleRef hwnd)
        {
            DestroyWindowCore(hwnd.Handle);
        }
        //PInvoke declarations
        [DllImport("Win32Lib.dll",CallingConvention = CallingConvention.Cdecl,CharSet = CharSet.Unicode)]
        internal static extern IntPtr CreateWindowCore(int width, int height, IntPtr hwndParent);
        [DllImport("Win32Lib.dll",CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        internal static extern bool DestroyWindowCore(IntPtr hwnd);
    }
}
