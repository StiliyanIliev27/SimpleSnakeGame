using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.Utilities
{
    public class ConsoleWindow
    {
        internal static class DllImports
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct COORD
            {

                public short X;
                public short Y;
                public COORD(short x, short y)
                {
                    this.X = x;
                    this.Y = y;
                }

            }
            [DllImport("kernel32.dll")]
            public static extern IntPtr GetStdHandle(int handle);
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool SetConsoleDisplayMode(
                IntPtr ConsoleOutput
                , uint Flags
                , out COORD NewScreenBufferDimensions
                );
        }

        public static void CustomizeConsole()
        {
            Console.OutputEncoding = Encoding.Unicode;
            IntPtr hConsole = DllImports.GetStdHandle(-11);   // get console handle
            DllImports.COORD xy = new DllImports.COORD(200, 200);
            DllImports.SetConsoleDisplayMode(hConsole, 1, out xy); // set the
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.CursorVisible = false;
        }
    }
}
