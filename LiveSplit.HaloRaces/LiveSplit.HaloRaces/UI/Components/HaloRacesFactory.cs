using System;
using System.Reflection;
using LiveSplit.Model;
using LiveSplit.UI.Components;

[assembly: ComponentFactory(typeof(LiveSplit.HaloRaces.UI.Components.HaloRacesFactory))]

namespace LiveSplit.HaloRaces.UI.Components
{
    class HaloRacesFactory : IComponentFactory
    {
        public string ComponentName => "HaloRaces";

        public string Description => "Allows the user to participate in HaloRuns races.";

        public ComponentCategory Category => ComponentCategory.Control;

        public IComponent Create(LiveSplitState state) => new HaloRacesComponent(state);

        public string UpdateName => ComponentName;

        public string XMLURL => "http://haloruns.com/update/Components/update.LiveSplit.HaloRaces.xml";

        public string UpdateURL => "http://haloruns.com/update/";

        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;
    }
}
