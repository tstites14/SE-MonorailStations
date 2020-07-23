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
        public class LargeRotatingLight
        {
            private IMyMotorStator rotor;
            private List<IMyReflectorLight> lights;

            public LargeRotatingLight(IMyBlockGroup lightGroup)
            {
                List<IMyMotorStator> rotors = new List<IMyMotorStator>();
                lightGroup.GetBlocksOfType(rotors);

                rotor = rotors[0];
                lightGroup.GetBlocksOfType(lights);
            }

            public void enable()
            {
                rotor.TargetVelocityRPM = 10.0f;

                lights.ForEach(light =>
                {
                    light.Enabled = true;
                });
            }

            public void disable()
            {
                rotor.TargetVelocityRPM = 0.0f;

                lights.ForEach(light =>
                {
                    light.Enabled = false;
                });
            }
        }
    }
}
