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
            private Program grid;

            public IMyMotorStator turntableRotor;
            public TurningStationStatus stationStatus;
            public LargeRotatingLight rotatingLight;

            private Dictionary<int, int> destinationDict;

            public TurningStation(string gridName, Program gridProgram)
            {
                name = gridName;
                grid = gridProgram;

                destinationDict = new Dictionary<int, int>
                {
                    { 1, 0 },
                    { 2, 45 },
                    { 3, 90 },
                    { 4, 135 },
                    { 5, 180 },
                    { 6, 225 },
                    { 7, 270 },
                    { 8, 305 }
                };

                turntableRotor = gridProgram.GridTerminalSystem.GetBlockWithName("Turning Station Rotor") as IMyMotorStator;

                sensors = new List<IMySensorBlock>();
                gridProgram.GridTerminalSystem.GetBlocksOfType(sensors);
                sensors.Where(item =>
                {
                    return item.IsSameConstructAs(connector);
                });

                IMyBlockGroup rotatingLightGroup = gridProgram.GridTerminalSystem.GetBlockGroupWithName("Rotating Light");
                rotatingLight = new LargeRotatingLight(rotatingLightGroup);
            }

            public override void sendData()
            {
                
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

            public void rotatePlatform(int endPosition)
            {
                int endAngle;
                destinationDict.TryGetValue(endPosition, out endAngle);


                if (endAngle < 180)
                {
                    turntableRotor.TargetVelocityRPM = 0.75f;

                    turntableRotor.UpperLimitDeg = endAngle;
                    turntableRotor.LowerLimitDeg = 0;
                }
                else if (endAngle > 180)
                {
                    turntableRotor.TargetVelocityRPM = -0.75f;

                    turntableRotor.UpperLimitDeg = 0;
                    turntableRotor.LowerLimitDeg = 180 - endAngle;
                }
                else
                {
                    return;
                }
            }

            private double radsToDegrees(float rads)
            {
                return rads * (180 / Math.PI);
            }
        }
    }
}
