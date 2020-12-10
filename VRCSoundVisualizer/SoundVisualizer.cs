using MelonLoader;
using UnityEngine;
using VRC;
using VRCSoundVisualizer;

[assembly: MelonInfo(typeof(SoundVisualizer), "VRCSoundVisualizer", "1.0.0", "benaclejames")]
[assembly: MelonGame("VRChat", "VRChat")]

namespace VRCSoundVisualizer
{
    internal class SoundVisualizer : MelonMod
    {
        public override void VRChat_OnUiManagerInit()
        {
            Hooking.SetupAllHooks();
        }
    }
}