using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RGBKeyboardSpectrograph
{
    class XmlToKeyMap
    {
        public KeyData[] LoadKeyLocations(string keyboardModel, string KeyboardRegion)
        {
            string kbdModel = GetModelCode(keyboardModel);
            string kbdRegion = GetRegionCode(KeyboardRegion);
            string xmlPath = Directory.GetCurrentDirectory() + "\\corsair_devices\\" + 
                                    kbdModel + "\\" + kbdModel + "_" + kbdRegion + ".xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            XmlElement root = doc.DocumentElement;
            XmlNodeList keys = root.SelectNodes("key");

            KeyData[] keyData = new KeyData[keys.Count];
            int k = 0;
            int p;
            KeyLayoutInfo GetKeyID = new KeyLayoutInfo();

            foreach (XmlNode key in keys)
            {
                keyData[k] = new KeyData();
                p = 0;
                foreach (XmlNode keyNodes in key.ChildNodes)
                {
                    if (keyNodes.Name == "name") { keyData[k].Name = keyNodes.InnerText; };
                    keyData[k].KeyID = GetKeyID.FindKeyID(keyData[k].Name);
                    if (keyNodes.Name == "geometry")
                    {
                        foreach (XmlNode geoData in keyNodes.ChildNodes)
                        {
                            if (geoData.Name == "point")
                            {
                                keyData[k].Coords[p] = new Point(int.Parse(geoData.Attributes["x"].Value),  int.Parse(geoData.Attributes["y"].Value));
                                p++;
                            }
                        }
                    }
                }
                k++;
            }
            return keyData;
        }

        public string GetModelCode(string keyboardModel)
        {
            string modelCode = "";

            switch (keyboardModel)
            {
                case "K65-RGB":
                    modelCode = "cgk65rgb";
                    break;
                case "K70-RGB":
                    modelCode = "k70rgb";
                    break;
                case "K95-RGB":
                    modelCode = "k95rgb";
                    break;
            }
            return modelCode;
        }

        public string GetRegionCode(string KeyboardRegion)
        {
            string modelRegion = "";

            switch (KeyboardRegion)
            {
                case "cn":
                case "na":
                case "tw":
                    modelRegion = "na";
                    break;
                case "be":
                case "ch":
                case "de":
                case "es":
                case "eu":
                case "fr":
                case "it":
                case "mex":
                case "nd":
                case "ru":
                case "uk":
                    modelRegion = "uk";
                    break;
                case "br":
                case "jp":
                case "kr":
                    modelRegion = KeyboardRegion;
                    break;
            }
            return modelRegion;
        }
    }

    public class KeyData
    {
        public string Name;
        public Point[] Coords = new Point[4];
        public int KeyID;
    }

    public class KeyLayoutInfo
    {
        private string[] layoutInfo;

        public KeyLayoutInfo()
        {
            layoutInfo = new string[] { "Escape", "GraveAccentAndTilde", "Tab", "CapsLock", "LeftShift",
                                        "LeftCtrl", "F12", "EqualsAndPlus", "WinLock", "Keypad7",
                                        "G1", "MR", "F1", "1", "Q",
                                        "A", "NonUsBackslash", "LeftGui", "PrintScreen", null,
                                        "Mute", "Keypad8", "G2", "M1", "F2",
                                        "2", "W", "S", "Z", "LeftAlt",
                                        "ScrollLock", "Backspace", "Stop", "Keypad9", "G3",
                                        "M2", "F3", "3", "E", "D",
                                        "X", null, "PauseBreak", "Delete", "ScanPreviousTrack",
                                        null, "G4", "M3", "F4", "4",
                                        "R", "F", "C", "Space", "Insert",
                                        "End", "PlayPause", "Keypad4", "G5", "G11",
                                        "F5", "5", "T", "G", "V", 
                                        null, "Home", "PageDown", "ScanNextTrack", "Keypad5",
                                        "G6", "G12", "F6", "6", "Y",
                                        "H", "B", null, "PageUp", "RightShift",
                                        "NumLock", "Keypad6", "G7", "G13", "F7",
                                        "7", "U", "J", "N", "RightAlt",
                                        "BracketRight", "RightCtrl", "KeypadSlash", "Keypad1", "G8",
                                        "G14", "F8", "8", "I", "K",
                                        "M", "RightGui", "Backslash", "UpArrow", "KeypadAsterisk",
                                        "Keypad2", "G9", "G15", "F9", "9",
                                        "O", "L", "CommaAndLessThan", "Application", null,
                                        "LeftArrow", "KeypadMinus", "Keypad3", "G10", "G16",
                                        "F10", "0", "P", "SemicolonAndColon", "PeriodAndBiggerThan",
                                        null, "Enter", "DownArrow", "KeypadPlus", "Keypad0",
                                        null, "G17", "F11", "MinusAndUnderscore", "BracketLeft",
                                        "ApostropheAndDoubleQuote", "SlashAndQuestionMark", "Brightness", null, "RightArrow",
                                        "KeypadEnter", "KeypadPeriodAndDelete", null, "G18", null};
        }

        public int FindKeyID(string keyName)
        {
            return Array.IndexOf(layoutInfo, keyName);
        }
    }
}
