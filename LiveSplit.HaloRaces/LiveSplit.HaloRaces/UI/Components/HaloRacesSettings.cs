using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveSplit.UI;
using System.Xml;

namespace LiveSplit.HaloRaces.UI.Components
{
    public partial class HaloRacesSettings : UserControl
    {
        public LayoutMode Mode { get; set; }

        public HaloRacesSettings()
        {
            InitializeComponent();
        }

        public bool RaceActive => cbRaceActive.Checked;

        public void SetSettings(XmlNode node)
        {
            var element = (XmlElement)node;
            //TextColor = SettingsHelper.ParseColor(element["TextColor"]);
            //OverrideTextColor = SettingsHelper.ParseBool(element["OverrideTextColor"]);
            //TimeColor = SettingsHelper.ParseColor(element["TimeColor"]);
            //OverrideTimeColor = SettingsHelper.ParseBool(element["OverrideTimeColor"]);
            //Accuracy = SettingsHelper.ParseEnum<TimeAccuracy>(element["Accuracy"]);
            //BackgroundColor = SettingsHelper.ParseColor(element["BackgroundColor"]);
            //BackgroundColor2 = SettingsHelper.ParseColor(element["BackgroundColor2"]);
            //GradientString = SettingsHelper.ParseString(element["BackgroundGradient"]);
            //Display2Rows = SettingsHelper.ParseBool(element["Display2Rows"], false);
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            var parent = document.CreateElement("Settings");
            CreateSettingsNode(document, parent);
            return parent;
        }

        private int CreateSettingsNode(XmlDocument document, XmlElement parent)
        {
            return SettingsHelper.CreateSetting(document, parent, "Version", "1.0"); // ^
            //SettingsHelper.CreateSetting(document, parent, "TextColor", TextColor) ^
            //SettingsHelper.CreateSetting(document, parent, "OverrideTextColor", OverrideTextColor) ^
            //SettingsHelper.CreateSetting(document, parent, "TimeColor", TimeColor) ^
            //SettingsHelper.CreateSetting(document, parent, "OverrideTimeColor", OverrideTimeColor) ^
            //SettingsHelper.CreateSetting(document, parent, "Accuracy", Accuracy) ^
            //SettingsHelper.CreateSetting(document, parent, "BackgroundColor", BackgroundColor) ^
            //SettingsHelper.CreateSetting(document, parent, "BackgroundColor2", BackgroundColor2) ^
            //SettingsHelper.CreateSetting(document, parent, "BackgroundGradient", BackgroundGradient) ^
            //SettingsHelper.CreateSetting(document, parent, "Display2Rows", Display2Rows);
        }

        private void linkHaloRunsRaceKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://haloruns.com");
        }
    }
}
