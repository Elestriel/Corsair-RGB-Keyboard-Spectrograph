using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RGBKeyboardSpectrograph
{
    class XmlProfileIO
    {
        public void SaveProfile(string keyboardID, Color[] keyData, string xmlPath)
        {
            //string xmlPath = Directory.GetCurrentDirectory() + "\\TestOutput.xml";

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.NewLineHandling = NewLineHandling.Entitize;
            xmlWriterSettings.Indent = true;

            XmlWriter xmlWriter = XmlWriter.Create(xmlPath, xmlWriterSettings);
            
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("profile");
            xmlWriter.WriteAttributeString("keyboard", keyboardID);
            
            for (int i = 0; i < keyData.Length; i++)
            {
                xmlWriter.WriteStartElement("key");
                xmlWriter.WriteAttributeString("id", i.ToString());
                xmlWriter.WriteString(ColorTranslator.ToHtml(keyData[i]));
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        public KeyColors LoadProfile(string xmlPath)
        {
            KeyColors keyData = new KeyColors();

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);

            XmlElement root = doc.DocumentElement;
            XmlNodeList keys = root.SelectNodes("key");
            try
            {
                string keyboardID = root.Attributes["keyboard"].Value;
            }
            catch
            {
                UpdateStatusMessage.ShowStatusMessage(3, "Failed to load profile.");
                keyData.Success = false;
                return keyData;
            }

            Color tempColor = new Color();
            int k = 0;

            foreach (XmlNode key in keys)
            {
                if (key.Name == "key") {
                    if (key.InnerText == "Transparent")
                    {
                        keyData.Colors[k] = Color.Transparent;
                    }
                    else
                    {
                        tempColor = ColorTranslator.FromHtml(key.InnerText);
                        keyData.Colors[k] = Color.FromArgb(127, tempColor.R, tempColor.G, tempColor.B);
                    }
                };
                k++;
            }
            keyData.Success = true;
            return keyData;
        }
    }

    public class KeyColors
    {
        public bool Success;
        public Color[] Colors = new Color[144];
    }
}