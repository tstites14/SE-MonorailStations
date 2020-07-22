using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System;
using VRage.Collections;
using VRage.Game.Components;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Game;
using VRage;
using VRageMath;

namespace IngameScript
{
    partial class Program
    {
        public class TurningStationStatus
        {
            StationStatus stationStatus;

            public Status()
            {
                stationStatus = StationStatus.Empty;
            }

            public Status(int statusInt)
            {
                stationStatus = (StationStatus) Enum.Parse(typeof(StationStatus), statusInt.ToString());
            }

            public enum StationStatus
            {
                Empty,
                Arrival,
                Docked,
                Rotating,
                Departure,
                Resetting
            }
        }
    }
}
