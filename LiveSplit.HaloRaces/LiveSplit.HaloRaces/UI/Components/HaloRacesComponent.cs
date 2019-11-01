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

        protected InfoTextComponent InternalComponent { get; set; }
        protected LiveSplitState CurrentState { get; set; }
        public HaloRacesSettings Settings { get; set; }

        public float PaddingTop => InternalComponent.PaddingTop;
        public float PaddingLeft => InternalComponent.PaddingLeft;
        public float PaddingBottom => InternalComponent.PaddingBottom;
        public float PaddingRight => InternalComponent.PaddingRight;
        public float VerticalHeight => InternalComponent.VerticalHeight;
        public float MinimumWidth => InternalComponent.MinimumWidth;
        public float HorizontalWidth => InternalComponent.HorizontalWidth;
        public float MinimumHeight => InternalComponent.MinimumHeight;
        public IDictionary<string, Action> ContextMenuControls => null;

        public HaloRacesComponent(LiveSplitState state)
        {
            InternalComponent = new InfoTextComponent("HaloRaces Info Text", "");
            InternalComponent.NameLabel.HasShadow = false;
            InternalComponent.ValueLabel.HasShadow = false;
            Settings = new HaloRacesSettings();
            state.OnStart += HaloRaces_OnStart;
            state.OnSplit += HaloRaces_OnSplit;
            state.OnUndoSplit += HaloRaces_OnUndoSplit;
            state.OnReset += HaloRaces_OnReset;
            CurrentState = state;
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
            LiveSplitState s = (LiveSplitState)sender;
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
                backgroundBrush = new SolidBrush(Color.OrangeRed);
            }

            g.FillRectangle(backgroundBrush, 0, 0, width, height);
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
            DrawBackground(g, state, width, VerticalHeight);
            InternalComponent.DrawVertical(g, state, width, clipRegion);
        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
            DrawBackground(g, state, HorizontalWidth, height);
            InternalComponent.DrawHorizontal(g, state, height, clipRegion);
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
            if (Settings.RaceActive)
            {
                InternalComponent.InformationValue = "Race Active";
            }
            else
            {
                InternalComponent.InformationValue = "No Active Race";
            }
            InternalComponent.Update(invalidator, state, width, height, mode);
        }

        public void Dispose()
        {
            CurrentState.OnStart -= HaloRaces_OnStart;
            CurrentState.OnSplit -= HaloRaces_OnSplit;
        }
    }
}
