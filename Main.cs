using MelonLoader;
using BoneLib;
using SLZ.Marrow.Warehouse;
using System;
using SLZ.Marrow.SceneStreaming;

namespace Labworks_Ammo_Saver
{
    internal partial class Main : MelonMod
    {
        public override void OnLateInitializeMelon()
        {
            base.OnLateInitializeMelon();
            BonelibCreator.CreateBoneMenu();

            BoneLib.Hooking.OnLevelInitialized += LevelInitialized;
        }

        internal static void LevelInitialized(LevelInfo info)
        {
            string palletTitle = SceneStreamer.Session.Level.Pallet.Title;
            string barcodeTitle = SceneStreamer.Session.Level.Barcode;
            {
                MelonLogger.Msg("Level is REDACTED!");
                AmmoFunctions.SetAmmo();
            }
        }
    }
}
