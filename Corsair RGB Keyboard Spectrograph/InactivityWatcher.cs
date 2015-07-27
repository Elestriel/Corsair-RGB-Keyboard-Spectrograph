using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace RGBKeyboardSpectrograph
{
    public class InactivityWatcher
    {
        public static void Watch()
        {
            InactivityStatusChanged.UpdateInactivity(0);
            uint idleTime;

            // Run the main watcher
            while (Program.WatchForInactivity == true)
            {
                idleTime =  IdleTimeFinder.GetIdleTime();
                if (Program.DevMode)
                { UpdateStatusMessage.ShowStatusMessage(1, "Inactive: " + idleTime); }

                // When inactivity timer pops, change layout and then enter a loop waiting for activity
                if ((IdleTimeFinder.GetIdleTime() / 1000) >= Program.InactivityTimeTrigger * 60 && Program.InactivityTimeTrigger > 0)
                {
                    InactivityStatusChanged.UpdateInactivity(1);

                    while ((idleTime / 1000) >= Program.InactivityTimeTrigger * 60) 
                    {
                        idleTime = IdleTimeFinder.GetIdleTime();
                        Thread.Sleep(100);
                    }

                    InactivityStatusChanged.UpdateInactivity(2);
                }

                Thread.Sleep(100);
            }
        }
    }

    internal struct LASTINPUTINFO
    {
        public uint cbSize;

        public uint dwTime;
    }

    /// <summary>
    /// Helps to find the idle time, (in ticks) spent since the last user input
    /// </summary>
    public class IdleTimeFinder
    {
        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("Kernel32.dll")]
        private static extern uint GetLastError();

        public static uint GetIdleTime()
        {
            LASTINPUTINFO lastInput = new LASTINPUTINFO();
            lastInput.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInput);
            GetLastInputInfo(ref lastInput);

            return ((uint)Environment.TickCount - lastInput.dwTime);
        }
        /// <summary>
        /// Get the last input time in ticks
        /// </summary>
        /// <returns></returns>
        public static long GetLastInputTime()
        {
            LASTINPUTINFO lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
            if (!GetLastInputInfo(ref lastInPut))
            {
                throw new Exception(GetLastError().ToString());
            }
            return lastInPut.dwTime;
        }
    }

}
