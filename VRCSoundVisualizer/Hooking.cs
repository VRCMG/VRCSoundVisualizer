using System;
using System.Reflection;
using Harmony;
using MelonLoader;
using UnhollowerBaseLib;
using UnityEngine;

namespace VRCSoundVisualizer
{
    public static class Hooking
    {
        private static HarmonyInstance _harmonyInstance;

        public static void SetupAllHooks()
        {
            _harmonyInstance = HarmonyInstance.Create("com.benacle.vrcsound");

            CameraVisualizer.SetupHooks(_harmonyInstance);
        }
    }
}