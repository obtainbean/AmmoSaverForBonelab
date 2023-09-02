using SLZ.Marrow.SceneStreaming;
using SLZ.Marrow.Warehouse;
using HarmonyLib;
using MelonLoader;

namespace Labworks_Ammo_Saver
{
    [HarmonyPatch(typeof(SceneStreamer), "Load", typeof(LevelCrateReference), typeof(LevelCrateReference))]
    public static class OnLoadPatch1
    {
        [HarmonyPrefix]
        public static void Load(LevelCrateReference level, LevelCrateReference loadLevel)
        {
            MelonLogger.Msg("Ran OnLoad Patch1");

            string barcodeName = level.Crate.Barcode;
            if (barcodeName == "volx4.LabWorksBoneworksPort.Level.BoneworksRedactedChamber" || barcodeName == "volx4.LabWorksBoneworksPort.Level.Boneworks07CentralStation" || barcodeName == "volx4.LabWorksBoneworksPort.Level.Boneworks06Warehouse" || barcodeName == "volx4.LabWorksBoneworksPort.Level.Boneworks05Sewers" || barcodeName == "volx4.LabWorksBoneworksPort.Level.Boneworks04Runoff" || barcodeName == "volx4.LabWorksBoneworksPort.Level.Boneworks02Museum" || barcodeName == "volx4.LabWorksBoneworksPort.Level.Boneworks01Breakroom" || barcodeName == "volx4.LabWorksBoneworksPort.Level.Boneworks03Streets" || barcodeName == "volx4.LabWorksBoneworksPort.Level.Boneworks05Sewers")
            {
                MelonLogger.Msg("Level is Labworks");
                BonelibCreator.OnSaveAmmo();
            }
            else
            {
                MelonLogger.Msg("Level ISNT Labworks");
                MelonLogger.Msg($"Barcode is: {barcodeName}");
            }
        }
    }

    [HarmonyPatch(typeof(SceneStreamer), "Load", typeof(string), typeof(string))]
    public static class OnLoadPatch2
    {
        public static void Load(string level, string loadLevel)
        {
            MelonLogger.Msg("Ran OnLoad Patch2");
            if (level == "volx4.LabWorksBoneworksPort.Level.BoneworksRedactedChamber" || level == "volx4.LabWorksBoneworksPort.Level.Boneworks07CentralStation" || level == "volx4.LabWorksBoneworksPort.Level.Boneworks06Warehouse" || level == "volx4.LabWorksBoneworksPort.Level.Boneworks05Sewers" || level == "volx4.LabWorksBoneworksPort.Level.Boneworks04Runoff" || level == "volx4.LabWorksBoneworksPort.Level.Boneworks02Museum" || level == "volx4.LabWorksBoneworksPort.Level.Boneworks01Breakroom" || level == "volx4.LabWorksBoneworksPort.Level.Boneworks03Streets" || level == "volx4.LabWorksBoneworksPort.Level.Boneworks05Sewers")
            {
                MelonLogger.Msg("Level is Labworks");
                BonelibCreator.OnSaveAmmo();
            }
            else
            {
                MelonLogger.Msg("Level ISNT Labworks");
                MelonLogger.Msg($"Barcode is: {level}");
            }
        }
    }
}
