using System.Collections;
using System.Collections.Generic;
using Harmony;
using MelonLoader;
using UnityEngine;
using VRC;
using VRC.UserCamera;

namespace VRCSoundVisualizer
{
    public static class CameraVisualizer
    {
        public static void SetupHooks(HarmonyInstance harmony)
        {
            // Camera Bloop Patch
            harmony.Patch(AccessTools.Method(typeof(UserCameraIndicator), "TimerBloop"),
                new HarmonyMethod(SymbolExtensions.GetMethodInfo((Player __0) => OnCameraBloop(__0))));
            
            // Camera Shutter Patch
            harmony.Patch(AccessTools.Method(typeof(UserCameraIndicator), "PhotoCapture"),
                new HarmonyMethod(SymbolExtensions.GetMethodInfo((Player __0) => OnCameraShutter(__0))));
        }
        
        private enum CameraColorStates
        {
            Normal,
            Amber,
            Green
        }
        
        private static readonly Dictionary<CameraColorStates, Color> CameraColorPresets = new Dictionary<CameraColorStates, Color>
        {
            {CameraColorStates.Normal, new Color(0.6544117f, 0.6544117f, 0.6544117f, 0.7843137f)},
            {CameraColorStates.Amber, new Color(0.9f, 0.8f, 0.4f, 0.9f)},
            {CameraColorStates.Green, new Color(0.0f, 1.0f, 0.0f, 0.9f)}
        };

        private static void OnCameraBloop(Player __0)
        {
            var indicatorMat = __0?.prop_VRCPlayer_0?.userCameraIndicator?.transform
                ?.FindChild("RemoteShape/camera_lens_mesh/lens_focus1")?.GetComponent<MeshRenderer>()?.material;

            if (indicatorMat != null)
                MelonCoroutines.Start(FlashCameraColor(indicatorMat, CameraColorStates.Amber, 0.4f));
        }

        private static void OnCameraShutter(Player __0)
        {
            var indicatorMat = __0?.prop_VRCPlayer_0?.userCameraIndicator?.transform
                ?.FindChild("RemoteShape/camera_lens_mesh/lens_focus1")?.GetComponent<MeshRenderer>()?.material;
            
            if (indicatorMat != null)
                MelonCoroutines.Start(FlashCameraColor(indicatorMat, CameraColorStates.Green, 0.25f));
        }

        private static IEnumerator FlashCameraColor(Material mat, CameraColorStates color, float durationInSeconds)
        {
            mat.color = CameraColorPresets[color];
            yield return new WaitForSeconds(durationInSeconds);
            mat.color = CameraColorPresets[CameraColorStates.Normal];
        }
    }
}