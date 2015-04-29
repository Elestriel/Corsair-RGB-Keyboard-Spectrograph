using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBKeyboardSpectrograph
{
    public interface IWriter
    {
        void Write(int iter, byte[] fftData, int CanvasWidth);
    }
}
