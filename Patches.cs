using SLZ.Marrow.SceneStreaming;
using SLZ.Marrow.Warehouse;
using HarmonyLib;
using MelonLoader;
using BoneLib;

namespace Labworks_Ammo_Saver
{
    [HarmonyPatch(typeof(SceneStreamer), "Load", typeof(LevelCrateReference), typeof(LevelCrateReference))]
    public static class OnLoadPatch1
    {
        [HarmonyPrefix]
        public static void Load(LevelCrateReference level, LevelCrateReference loadLevel)
        {
            string previousTitle = SceneStreamer.Session.Level.Pallet.Title;
            string barcode = SceneStreamer.Session.Level.Barcode;
        
                AmmoFunctions.SaveAmmo();
            }
        }
    }

    [HarmonyPatch(typeof(SceneStreamer), "Load", typeof(string), typeof(string))]
    public static class OnLoadPatch2
    {
        [HarmonyPrefix]
        public static void Load(string level, string loadLevel)
        {
            string previousTitle = SceneStreamer.Session.Level.Pallet.Title;
            string barcode = SceneStreamer.Session.Level.Barcode;
            if (previousTitle == "LabWorksBoneworksPort" && barcode != "volx4.LabWorksBoneworksPort.Level.BoneworksRedactedChamber" && barcode != "volx4.LabWorksBoneworksPort.Level.BoneworksMainMenu")
            {
                AmmoFunctions.SaveAmmo();
            }
        }
    }
}
