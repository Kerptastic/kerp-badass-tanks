using System;
using System.Runtime.InteropServices;

namespace BadAssTanks
{
    /// <summary>
    /// Uses C++ system libraries for calculating precise time. Needed
    /// for Managed DirectX - may be able to delete eventually.
    /// </summary>
    public class GameTimer
    {
        [DllImport("winmm.dll")]
        public static extern uint timeBeginPeriod(uint uPeriod);

        [DllImport("winmm.dll")]
        public static extern uint timeGetTime();
    }
}
