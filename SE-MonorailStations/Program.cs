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
using System.Diagnostics;

namespace IngameScript
{
    partial class Program : MyGridProgram
    {
        public Program()
        {

        }

        public void Save()
        {

        }

        public void Main(string argument, UpdateType updateSource)
        {
            var station = getStationType();
            
            if (station.GetType() == typeof(StationPlatform))
            {
                
            }
            else if (station.GetType() == typeof(TurningStation))
            {

            }
            else
            {
                return;
            }
        }

        StationBase getStationType()
        {
            string grid = Me.CubeGrid.CustomName;

            List<IMySensorBlock> sensors = new List<IMySensorBlock>();
            GridTerminalSystem.GetBlocksOfType(sensors);

            if (grid.Contains("Station Platform"))
            {
                return new StationPlatform(grid, sensors);
            }
            else if (grid.Contains("Turning Station"))
            {
                return new TurningStation(grid, this);
            }
            else
            {
                return null;
            }
        }
    }
}
