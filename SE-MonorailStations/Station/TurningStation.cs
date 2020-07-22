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
using VRageRender;

namespace IngameScript
{
    partial class Program
    {
        public class TurningStation : StationBase
        {
            private IMyMotorStator turntableRotor;

            private Dictionary<int, int> destinationDict;
            private Status stationStatus;

            public TurningStation(string gridName, List<IMySensorBlock> sensors)
            {
                name = gridName;

                destinationDict = new Dictionary<int, int>
                {
                    { 1, 0 },
                    { 2, 45 },
                    { 3, 90 },
                    { 4, 135 },
                    { 5, 180 },
                    { 6, 225 },
                    { 7, 270 },
                    { 8, 305 },
                    { 9, 0 }
                };

                this.sensors = sensors;
                this.sensors.Where(item =>
                {
                    return item.CubeGrid.Name == gridName;
                });
            }

            public override void sendData()
            {

            }

            enum Status
            {
                Empty,
                Arrival,
                Docked,
                Rotating,
                Departure,
                Resetting
            }

            public bool isRotationRequired(int requestedAngle)
            {
                int currentAngle = Convert.ToInt32(radsToDegrees(turntableRotor.Angle));

                if (currentAngle != requestedAngle)
                {
                    return true;
                }

                return false;
            }

            private double radsToDegrees(float rads)
            {
                return rads * (180 / Math.PI);
            }
        }
    }
}
