using System;
using System.Runtime.InteropServices;

namespace BadAssTanks
{
    class GameTimer
    {
        [DllImport("winmm.dll")]
        public static extern uint timeBeginPeriod(uint uPeriod);

        [DllImport("winmm.dll")]
        public static extern uint timeGetTime();
    }
}
