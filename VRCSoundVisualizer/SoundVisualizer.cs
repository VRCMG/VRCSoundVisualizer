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

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.H))
                VRCPlayer.field_Internal_Static_VRCPlayer_0.userCameraIndicator.TimerBloop(Player.prop_Player_0);
            if (Input.GetKeyDown(KeyCode.J))
                VRCPlayer.field_Internal_Static_VRCPlayer_0.userCameraIndicator.PhotoCapture(Player.prop_Player_0);
        }
    }
}