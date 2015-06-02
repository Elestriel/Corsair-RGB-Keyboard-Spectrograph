using System;
using System.Drawing;
using System.Threading;

namespace RGBKeyboardSpectrograph
{
    public class SpecialEffects
    {
        public static void KeyboardControl(string SelectedEffect = "none")
        {
            if (Program.RunKeyboardThread != 3) { return; };

            UpdateStatusMessage.ShowStatusMessage(2, "Starting Effects");

            KeyboardWriter keyWriter = new KeyboardWriter();
            SingleKeyFade[] keyMatrix = new SingleKeyFade[144];
            StaticColorCollection[] sendMatrix = new StaticColorCollection[144];
            Random rnd = new Random();

            for (int i = 0; i < 144; i++)
            {
                keyMatrix[i] = new SingleKeyFade(0, 0, 0);
                sendMatrix[i] = new StaticColorCollection();
            }

            while (Program.RunKeyboardThread == 3)
            {
                int keyToLight = rnd.Next(0, 143);

                // Try 20 times to find a key that is finished its animation.
                // If a key can't be found, give up and run another cycle.
                for (int r = 0; r < 20; r++)
                {
                    if (keyMatrix[keyToLight].EffectInProgress == false)
                    {
                        switch (Program.EfColors.Mode)
                        {
                            case 1:
                                keyMatrix[keyToLight] = new SingleKeyFade(
                                    (byte)Program.EfColors.StartR,
                                    (byte)Program.EfColors.StartG,
                                    (byte)Program.EfColors.StartB,
                                    (byte)Program.EfColors.EndR,
                                    (byte)Program.EfColors.EndG,
                                    (byte)Program.EfColors.EndB);
                                break;
                            case 2:
                                keyMatrix[keyToLight] = new SingleKeyFade(
                                    (byte)rnd.Next(Program.EfColors.SRandRLow, Program.EfColors.SRandRHigh),
                                    (byte)rnd.Next(Program.EfColors.SRandGLow, Program.EfColors.SRandGHigh),
                                    (byte)rnd.Next(Program.EfColors.SRandBLow, Program.EfColors.SRandBHigh),
                                    (byte)Program.EfColors.EndR,
                                    (byte)Program.EfColors.EndG,
                                    (byte)Program.EfColors.EndB);
                                break;
                            case 3:
                                keyMatrix[keyToLight] = new SingleKeyFade(
                                    (byte)Program.EfColors.StartR,
                                    (byte)Program.EfColors.StartG,
                                    (byte)Program.EfColors.StartB,
                                    (byte)rnd.Next(Program.EfColors.ERandRLow, Program.EfColors.ERandRHigh),
                                    (byte)rnd.Next(Program.EfColors.ERandGLow, Program.EfColors.ERandGHigh),
                                    (byte)rnd.Next(Program.EfColors.ERandBLow, Program.EfColors.ERandBHigh));
                                break;
                            case 4:
                                keyMatrix[keyToLight] = new SingleKeyFade(
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
                        sendMatrix[i].SetD(keyMatrix[i].KeyColor);
                    }
                    keyMatrix[i].IncrementStep();
                }

                keyWriter.Write(sendMatrix, true);
                Thread.Sleep(Program.EfSettings.Frequency);
            }

            UpdateStatusMessage.ShowStatusMessage(2, "Stopping Effects");
        }
    }
    
    class SingleKeyFade
    {
        public bool EffectInProgress;
        private byte R;
        private byte G;
        private byte B;
        public Color KeyColor { 
            get 
            { return Color.FromArgb(255, this.R, this.G, this.B); }
        }

        private byte sR, sG, sB, eR, eG, eB;
        
        private int CycleCount = 0;
        private int CycleLimit = Program.EfSettings.Duration;

        public SingleKeyFade(byte sR, byte sG, byte sB)
        {
            this.R = sR;
            this.G = sG;
            this.B = sB;
            this.EffectInProgress = false;
        }

        public SingleKeyFade(byte sR, byte sG, byte sB, byte eR, byte eG, byte eB)
        {
            //this.R = sR;
            //this.G = sG;
            //this.B = sB;
            this.sR = sR;
            this.sG = sG;
            this.sB = sB;
            this.eR = eR;
            this.eG = eG;
            this.eB = eB;
            this.EffectInProgress = true;
        }
        
        public void IncrementStep()
        {
            int steps = (int)(CycleLimit - (CycleLimit * 0.75));
            double stepR = (sR - eR) / (double)steps;
            double stepG = (sG - eG) / (double)steps;
            double stepB = (sB - eB) / (double)steps;

            this.CycleCount += 1;

            if (this.CycleCount < (this.CycleLimit * 0.75))
            {
                this.R = this.sR;
                this.G = this.sG;
                this.B = this.sB;
            }
            else if (this.CycleCount >= (this.CycleLimit * 0.75) && this.CycleCount < this.CycleLimit)
            {
                this.R = (byte)(Math.Abs(this.R - stepR));
                this.G = (byte)(Math.Abs(this.G - stepG));
                this.B = (byte)(Math.Abs(this.B - stepB));
            }
            else if (this.CycleCount >= this.CycleLimit)
            {
                this.R = this.eR;
                this.G = this.eG;
                this.B = this.eB;
                this.EffectInProgress = false;
            }
        }
    }
}


/* Thread Status Index
-2: Initiation Failed
-1: Not yet created
 0: Destroyed
 1: Test Mode
 2: Spectro Running
 3: Effects Running
 */

/* 40FPS, 25ms refresh */