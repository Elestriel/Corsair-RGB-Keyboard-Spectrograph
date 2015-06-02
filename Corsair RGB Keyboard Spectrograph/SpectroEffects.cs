using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBKeyboardSpectrograph
{
    class SpectroEffects
    {
        public byte Red;
        public byte Grn;
        public byte Blu;

        public SpectroEffects(string EffectType, string EffectName, int column, int row) {
            switch (EffectType) {
                case "Background":
                    Background(EffectName, column, row);
                    break;
                case "SpectroForeground":
                    SpectroForeground(EffectName, column, row);
                    break;
                default:
                    break;
            }
        }

        private void Background(string EffectName, int i, int k)
        {
            switch (Program.SpectroBg.Mode)
            {
                case "Solid Colour":
                    this.Red = (byte)(Program.SpectroBg.Color.Red);
                    this.Grn = (byte)(Program.SpectroBg.Color.Grn);
                    this.Blu = (byte)(Program.SpectroBg.Color.Blu);
                    break;
                case "Rainbow Right":
                    this.Red = (byte)((Program.SpectroBg.Brightness / 10) * (Math.Sin(((i - Program.SpectroBg.Step) / Program.SpectroBg.Width) * 2 * 3.14f) + 1));
                    this.Grn = (byte)((Program.SpectroBg.Brightness / 10) * (Math.Sin((((i - Program.SpectroBg.Step) / Program.SpectroBg.Width) * 2 * 3.14f) - (6.28f / 3)) + 1));
                    this.Blu = (byte)((Program.SpectroBg.Brightness / 10) * (Math.Sin((((i - Program.SpectroBg.Step) / Program.SpectroBg.Width) * 2 * 3.14f) + (6.28f / 3)) + 1));
                    break;
                case "Rainbow Left":
                    this.Red = (byte)((Program.SpectroBg.Brightness / 10) * (Math.Sin(((i + Program.SpectroBg.Step) / Program.SpectroBg.Width) * 2 * 3.14f) + 1));
                    this.Grn = (byte)((Program.SpectroBg.Brightness / 10) * (Math.Sin((((i + Program.SpectroBg.Step) / Program.SpectroBg.Width) * 2 * 3.14f) - (6.28f / 3)) + 1));
                    this.Blu = (byte)((Program.SpectroBg.Brightness / 10) * (Math.Sin((((i + Program.SpectroBg.Step) / Program.SpectroBg.Width) * 2 * 3.14f) + (6.28f / 3)) + 1));
                    break;
                case "Rainbow Pulse":
                    this.Red = (byte)((Program.SpectroBg.Brightness / 10) * (Math.Sin((Program.SpectroBg.Step / Program.SpectroBg.Width) * 2 * 3.14f) + 1));
                    this.Grn = (byte)((Program.SpectroBg.Brightness / 10) * (Math.Sin(((Program.SpectroBg.Step / Program.SpectroBg.Width) * 2 * 3.14f) - (6.28f / 3)) + 1));
                    this.Blu = (byte)((Program.SpectroBg.Brightness / 10) * (Math.Sin(((Program.SpectroBg.Step / Program.SpectroBg.Width) * 2 * 3.14f) + (6.28f / 3)) + 1));
                    break;
                case "Rainbow Swipes":
                    this.Red = (byte)((Program.SpectroBg.Brightness / 10) * (Math.Sin((i + Program.SpectroBg.Step / Program.SpectroBg.Width) * 2 * 3.14f) + 1));
                    this.Grn = (byte)((Program.SpectroBg.Brightness / 10) * (Math.Sin(((i + Program.SpectroBg.Step / Program.SpectroBg.Width) * 2 * 3.14f) - (6.28f / 3)) + 1));
                    this.Blu = (byte)((Program.SpectroBg.Brightness / 10) * (Math.Sin(((i + Program.SpectroBg.Step / Program.SpectroBg.Width) * 2 * 3.14f) + (6.28f / 3)) + 1));
                    break;
            }
        }

        private void SpectroForeground(string EffectName, int i, int k)
        {
            switch (EffectName) {
                case "Solid Colour":
                    this.Red = (byte)Program.SpectroBars.Color.Red;
                    this.Grn = (byte)Program.SpectroBars.Color.Grn;
                    this.Blu = (byte)Program.SpectroBars.Color.Blu;
                    break;
                case "Rainbow Right":
                    this.Red = (byte)((Program.SpectroBars.Brightness / 10) * (Math.Sin(((i - Program.SpectroBars.Step) / Program.SpectroBars.Width) * 2 * 3.14f) + 1));
                    this.Grn = (byte)((Program.SpectroBars.Brightness / 10) * (Math.Sin((((i - Program.SpectroBars.Step) / Program.SpectroBars.Width) * 2 * 3.14f) - (6.28f / 3)) + 1));
                    this.Blu = (byte)((Program.SpectroBars.Brightness / 10) * (Math.Sin((((i - Program.SpectroBars.Step) / Program.SpectroBars.Width) * 2 * 3.14f) + (6.28f / 3)) + 1));
                    break;
                case "Rainbow Left":
                    this.Red = (byte)((Program.SpectroBars.Brightness / 10) * (Math.Sin(((i + Program.SpectroBars.Step) / Program.SpectroBars.Width) * 2 * 3.14f) + 1));
                    this.Grn = (byte)((Program.SpectroBars.Brightness / 10) * (Math.Sin((((i + Program.SpectroBars.Step) / Program.SpectroBars.Width) * 2 * 3.14f) - (6.28f / 3)) + 1));
                    this.Blu = (byte)((Program.SpectroBars.Brightness / 10) * (Math.Sin((((i + Program.SpectroBars.Step) / Program.SpectroBars.Width) * 2 * 3.14f) + (6.28f / 3)) + 1));
                    break;
                case "Rainbow Pulse":
                    this.Red = (byte)((Program.SpectroBars.Brightness / 10) * (Math.Sin((Program.SpectroBars.Step / Program.SpectroBars.Width) * 2 * 3.14f) + 1));
                    this.Grn = (byte)((Program.SpectroBars.Brightness / 10) * (Math.Sin(((Program.SpectroBars.Step / Program.SpectroBars.Width) * 2 * 3.14f) - (6.28f / 3)) + 1));
                    this.Blu = (byte)((Program.SpectroBars.Brightness / 10) * (Math.Sin(((Program.SpectroBars.Step / Program.SpectroBars.Width) * 2 * 3.14f) + (6.28f / 3)) + 1));
                    break;
                case "Static Rainbow":
                    this.Red = (byte)((Program.SpectroBars.Brightness / 10) * (Math.Sin((i / Program.SpectroBars.Width) * 2 * 3.14f) + 1));
                    this.Grn = (byte)((Program.SpectroBars.Brightness / 10) * (Math.Sin(((i / Program.SpectroBars.Width) * 2 * 3.14f) - (6.28f / 3)) + 1));
                    this.Blu = (byte)((Program.SpectroBars.Brightness / 10) * (Math.Sin(((i / Program.SpectroBars.Width) * 2 * 3.14f) + (6.28f / 3)) + 1));
                    break;
                case "Classic Bars":
                            byte LitBright = (byte)(Program.SpectroBars.Brightness / 10);
                            if (k == 1 || k == 0) { 
                                this.Red = LitBright;
                                this.Grn = 0;
                                this.Blu = 0;
                            }
                            else if (k == 2)
                            {
                                this.Red = LitBright;
                                this.Grn = LitBright;
                                this.Blu = 0;
                            }
                            else { 
                                this.Red = 0;
                                this.Grn = LitBright;
                                this.Blu = 0;
                            };
                    break;
                default:
                    break;
        }

        }
    }
}
