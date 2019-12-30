using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSplit.HaloRaces.UI.Components
{
    enum RaceStatus
    {
        NO_RACE,
        WAITING_FOR_PLAYERS,
        STARTING,
        ACTIVE,
        FINISHED
    }

    struct RaceParticipant
    {
        public string Name { get; set; }
        public bool Ready { get; set; }
        public int CurrentLevel { get; set; }
        public TimeSpan LastSplitTime { get; set; }
        public string Standing { get; set; }
    }

    class HaloRacesRaceManager
    {
        public int CurrentRaceID { get; set; }
        public RaceStatus CurrentRaceStatus { get; set; }

        // OpenRace()
        // RaceBegin()
        // RaceUpdate()
        // CloseRace()
    }
}
