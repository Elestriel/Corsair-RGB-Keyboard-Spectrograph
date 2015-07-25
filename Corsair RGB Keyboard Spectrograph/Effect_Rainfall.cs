using System;
using System.Drawing;
using System.Threading;

namespace RGBKeyboardSpectrograph
{
    class Effect_Rainfall
    {
        /*
        public static void KeyboardControl()
        {
            if (Program.RunKeyboardThread != 3) { return; };

            UpdateStatusMessage.ShowStatusMessage(2, "Starting Effects");

            KeyboardWriter keyWriter = new KeyboardWriter();

            SingleKeyFade[] lightMatrix = new SingleKeyFade[144];
            StaticColorCollection[] sendMatrix = new StaticColorCollection[144];
            
            Random rnd = new Random();

            for (int i = 0; i < 144; i++)
            {
                lightMatrix[i] = new SingleKeyFade(0, 0, 0);
                sendMatrix[i] = new StaticColorCollection();
            }

            while (Program.RunKeyboardThread == 3)
            {
                int keyToLight = rnd.Next(0, 148);

                // Try 20 times to find a key that is finished its animation.
                // If a key can't be found, give up and run another cycle.
                for (int r = 0; r < 20; r++)
                {
                    if (lightMatrix[keyToLight].EffectInProgress == false)
                    {
                        switch (Program.EfColors.Mode)
                        {
                            case 1:
                                lightMatrix[keyToLight] = new SingleKeyFade(
                                    (byte)Program.EfColors.StartR,
                                    (byte)Program.EfColors.StartG,
                                    (byte)Program.EfColors.StartB,
                                    (byte)Program.EfColors.EndR,
                                    (byte)Program.EfColors.EndG,
                                    (byte)Program.EfColors.EndB);
                                break;
                            case 2:
                                lightMatrix[keyToLight] = new SingleKeyFade(
                                    (byte)rnd.Next(Program.EfColors.SRandRLow, Program.EfColors.SRandRHigh),
                                    (byte)rnd.Next(Program.EfColors.SRandGLow, Program.EfColors.SRandGHigh),
                                    (byte)rnd.Next(Program.EfColors.SRandBLow, Program.EfColors.SRandBHigh),
                                    (byte)Program.EfColors.EndR,
                                    (byte)Program.EfColors.EndG,
                                    (byte)Program.EfColors.EndB);
                                break;
                            case 3:
                                lightMatrix[keyToLight] = new SingleKeyFade(
                                    (byte)Program.EfColors.StartR,
                                    (byte)Program.EfColors.StartG,
                                    (byte)Program.EfColors.StartB,
                                    (byte)rnd.Next(Program.EfColors.ERandRLow, Program.EfColors.ERandRHigh),
                                    (byte)rnd.Next(Program.EfColors.ERandGLow, Program.EfColors.ERandGHigh),
                                    (byte)rnd.Next(Program.EfColors.ERandBLow, Program.EfColors.ERandBHigh));
                                break;
                            case 4:
                                lightMatrix[keyToLight] = new SingleKeyFade(
                                    (byte)rnd.Next(Program.EfColors.SRandRLow, Program.EfColors.SRandRHigh),
                                    (byte)rnd.Next(Program.EfColors.SRandGLow, Program.EfColors.SRandGHigh),
                                    (byte)rnd.Next(Program.EfColors.SRandBLow, Program.EfColors.SRandBHigh),
                                    (byte)rnd.Next(Program.EfColors.ERandRLow, Program.EfColors.ERandRHigh),
                                    (byte)rnd.Next(Program.EfColors.ERandGLow, Program.EfColors.ERandGHigh),
                                    (byte)rnd.Next(Program.EfColors.ERandBLow, Program.EfColors.ERandBHigh));
                                break;
                        }
                        break;
                    }
                }

                for (int i = 0; i < 144; i++)
                {
                    if (Program.AnimationsUseStaticKeys == true && Program.StaticKeyColorsBytes[i].Transparent == false)
                    {
                        sendMatrix[i].Set(Program.StaticKeyColorsBytes[i].KeyColor);
                    }
                    else
                    {
                        sendMatrix[i].SetD(lightMatrix[i].KeyColor);
                    }
                    lightMatrix[i].IncrementStep();
                }

                for (int i = 144; i < 148; i++)
                {
                    mouseMatrix[i - 144].Set(lightMatrix[i].KeyColor);
                    lightMatrix[i].IncrementStep();
                }

                keyWriter.Write(sendMatrix, true);
                if (Program.IncludeMouseInEffects)
                {
                    if (!Program.AnimationsUseStaticKeys)
                    {
                        mouseWriter.Write(mouseMatrix, true);
                    }
                    else
                    {
                        mouseWriter.Write(Program.MouseColors, true);
                    };
                };
                Thread.Sleep(Program.EfSettings.Frequency);
            }

            UpdateStatusMessage.ShowStatusMessage(2, "Stopping Effects");
        }
         * */
    }
}
