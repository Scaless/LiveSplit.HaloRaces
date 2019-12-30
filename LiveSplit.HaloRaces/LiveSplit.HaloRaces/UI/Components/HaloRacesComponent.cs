using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


// For Console Debugging
using System.Runtime.InteropServices;


namespace LiveSplit.HaloRaces.UI.Components
{
    class HaloRacesComponent : IComponent
    {
        // For Console Debugging
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public string ComponentName => "HaloRaces";

        protected HaloRacesPusherClient PusherClient { get; set; }
        //protected InfoTextComponent InternalComponent { get; set; }
        protected LiveSplitState CurrentState { get; set; }
        public HaloRacesSettings Settings { get; set; }
        public HaloRacesRaceManager RaceManager { get; set; }

        private string HeaderText { get; set; }
        private string RaceMode { get; set; }
        private int PlayerCount { get; set; } = 5;

        public float PaddingTop => 0;
        public float PaddingLeft => 0;
        public float PaddingBottom => 0;
        public float PaddingRight => 0;
        public float VerticalHeight => 200;
        public float MinimumHeight => 200;
        public float HorizontalWidth => 500;
        public float MinimumWidth => 500;

        public IDictionary<string, Action> ContextMenuControls => null;

        public HaloRacesComponent(LiveSplitState state)
        {
            //InternalComponent = new InfoTextComponent("test", "");
            //InternalComponent.NameLabel.HasShadow = false;
            //InternalComponent.ValueLabel.HasShadow = false;

            HeaderText = "Header Text";

            Settings = new HaloRacesSettings();
            PusherClient = new HaloRacesPusherClient();
            RaceManager = new HaloRacesRaceManager();

            state.OnStart += HaloRaces_OnStart;
            state.OnSplit += HaloRaces_OnSplit;
            state.OnUndoSplit += HaloRaces_OnUndoSplit;
            state.OnReset += HaloRaces_OnReset;
            CurrentState = state;

            Settings.CurrentSplits.Clear();
            foreach (Segment s in state.Run)
            {
                Settings.CurrentSplits.Add(s.Name);
            }

            AllocConsole();
        }

        private void HaloRaces_OnReset(object sender, TimerPhase value)
        {
            LiveSplitState s = (LiveSplitState)sender;
        }

        private void HaloRaces_OnUndoSplit(object sender, EventArgs e)
        {
            LiveSplitState s = (LiveSplitState)sender;
        }

        private void HaloRaces_OnSplit(object sender, System.EventArgs e)
        {
            LiveSplitState s = (LiveSplitState)sender;

            if (s.AttemptEnded.Time != new DateTime())
            {
                Console.WriteLine("Race: Final run time: " + s.CurrentAttemptDuration);
            }
            else
            {
                Console.WriteLine("Race: Split at time: " + s.CurrentAttemptDuration);
            }
        }

        private void HaloRaces_OnStart(object sender, System.EventArgs e)
        {
            LiveSplitState state = (LiveSplitState)sender;
            Console.WriteLine("Race: Timer Started");
        }

        private void DrawBackground(Graphics g, LiveSplitState state, float width, float height)
        {
            SolidBrush backgroundBrush;

            if (Settings.RaceActive)
            {
                backgroundBrush = new SolidBrush(Color.DarkOliveGreen);
            } 
            else
            {
                backgroundBrush = new SolidBrush(Color.DimGray);
            }

            g.FillRectangle(backgroundBrush, 0, 0, width, height);
        }

        public void DrawChartRaceWaiting(Graphics g, LiveSplitState state, float width, float height)
        {
            var br = new SolidBrush(Color.Black);
            var pen = new Pen(br, 2);
            var font = state.LayoutSettings.TextFont;

            var headerSize = 24;
            var rowCount = PlayerCount;

            var gridCount = rowCount + 1;

            for (int i = 0; i < gridCount; i++)
            {
                var yLevel = i * 24 + headerSize;
                g.DrawLine(pen, 0, yLevel, width, yLevel);
            }

            for (int i = 0; i < rowCount; i++)
            {
                var yLevel = i * 24 + headerSize;
                g.DrawString("Player " + i, font, br, 0, yLevel);
                g.DrawString("Ready: " + (i > 2 ? "YES" : "NO"), font, br, 80, yLevel);
            }

            g.DrawLine(pen, 1, headerSize, 1, gridCount * headerSize);
            g.DrawLine(pen, width, headerSize, width, gridCount * headerSize);
        }

        public void DrawChartRaceActive(Graphics g, LiveSplitState state, float width, float height)
        {
            var br = new SolidBrush(Color.Black);
            var brGreen = new SolidBrush(Color.Red);
            var pen = new Pen(br, 2);
            var font = state.LayoutSettings.TextFont;

            var headerSize = 24;
            var rowCount = PlayerCount;

            var gridCount = rowCount + 1;

            for(int i = 0; i < gridCount; i++)
            {
                var yLevel = i * 24 + headerSize;
                g.DrawLine(pen, 0, yLevel, width, yLevel);
            }

            var rng = new Random();

            for(int i = 0; i < rowCount; i++)
            {
                var yLevel = i * 24 + headerSize;
                g.DrawString("Player " + i, font, br, 0, yLevel);
                g.DrawString("Pillar of Autumn", font, br, 80, yLevel);

                TimeSpan t = new TimeSpan(rng.Next());
                g.DrawString(t.ToString(), font, br, 240, yLevel);
            }

            g.DrawLine(pen, 1, headerSize, 1, gridCount * headerSize);
            g.DrawLine(pen, width, headerSize, width, gridCount * headerSize);
        }

        public void DrawHeader(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
            var br = new SolidBrush(Color.Black);
            var pen = new Pen(br, 1);
            var font = state.LayoutSettings.TextFont;

            g.DrawString(HeaderText, font, br, 0, 0);
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
            var br = new SolidBrush(Color.Black);
            var pen = new Pen(br, 1);
            var font = state.LayoutSettings.TextFont;
            
            DrawBackground(g, state, width, VerticalHeight);
            DrawHeader(g, state, width, clipRegion);

            switch (RaceMode)
            {
                case "WAITING_FOR_PLAYERS":
                    DrawChartRaceWaiting(g, state, width, VerticalHeight);
                    break;
                case "STARTING":
                    break;
                case "ACTIVE":
                    DrawChartRaceActive(g, state, width, VerticalHeight);
                    break;
                case "FINISHED":
                    break;
                case "NO_RACE":
                default:
                    break;
            }

            //InternalComponent.DrawVertical(g, state, width, clipRegion);
        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
            DrawBackground(g, state, HorizontalWidth, height);
            //InternalComponent.DrawHorizontal(g, state, height, clipRegion);
        }

        public Control GetSettingsControl(LayoutMode mode)
        {
            Settings.Mode = mode;
            return Settings;
        }

        public void SetSettings(System.Xml.XmlNode settings)
        {
            Settings.SetSettings(settings);
        }

        public System.Xml.XmlNode GetSettings(System.Xml.XmlDocument document)
        {
            return Settings.GetSettings(document);
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            HeaderText = PusherClient.InfoText;

            if (Settings.RaceActive)
            {
                HeaderText = Settings.RaceName;
            }
            else
            {
                HeaderText = "No Active Race";
            }

            RaceMode = Settings.RaceMode;
            PlayerCount = Settings.PlayerCount;

            invalidator.Invalidate(0, 0, width, height);

            //InternalComponent.Update(invalidator, state, width, height, mode);

            if (state.Run.HasChanged)
            {
                Settings.CurrentSplits.Clear();
                foreach (Segment s in state.Run)
                {
                    Settings.CurrentSplits.Add(s.Name);
                }
            }
        }

        public void Dispose()
        {
            CurrentState.OnStart -= HaloRaces_OnStart;
            CurrentState.OnSplit -= HaloRaces_OnSplit;
        }
    }
}
