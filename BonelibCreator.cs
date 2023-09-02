using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoneLib;
using BoneLib.BoneMenu;
using BoneLib.BoneMenu.Elements;
using Il2CppSystem;
using MelonLoader;
using SLZ.Data;
using SLZ.Marrow.Data;
using SLZ.Player;
using UnityEngine;

namespace Labworks_Ammo_Saver
{
    public static class BonelibCreator
    {
        private static MelonPreferences_Category category;

        internal static MenuCategory labworksAmmoSaverCategory;
        public static void CreateBoneMenu()
        {
            labworksAmmoSaverCategory = MenuManager.CreateCategory("Labworks Ammo Saver", Color.white);

            labworksAmmoSaverCategory.CreateFunctionElement("Reset Ammo", Color.yellow, () => ClearAmmo());

            category = MelonPreferences.CreateCategory("Labworks_Ammo_Saver");
            ammo = category.CreateEntry<List<int>>("Ammo", null);
        }

        public static MelonPreferences_Entry<List<int>> ammo;
        public static void OnSaveAmmo()
        {
            List<int> ammoCount = new List<int>();
            ammoCount.Add(Player.rigManager.AmmoInventory.GetCartridgeCount("light"));
            ammoCount.Add(Player.rigManager.AmmoInventory.GetCartridgeCount("medium"));
            ammoCount.Add(Player.rigManager.AmmoInventory.GetCartridgeCount("heavy"));

            ammo.Value = ammoCount;
            ammo.Save();
        }

        private static void ClearAmmo()
        {
            Player.rigManager.AmmoInventory.ClearAmmo();

            ammo.Value[0] = 0;
            ammo.Value[1] = 0;
            ammo.Value[2] = 0;

            ammo.Save();
        }

        private static void SetAmmo()
        {
            List<int> ammoCount = ammo.Value;

            Player.rigManager.AmmoInventory.ClearAmmo();

            Player.rigManager.AmmoInventory.AddCartridge(Player.rigManager.AmmoInventory.lightAmmoGroup, ammoCount[0]);
            Player.rigManager.AmmoInventory.AddCartridge(Player.rigManager.AmmoInventory.mediumAmmoGroup, ammoCount[1]);
            Player.rigManager.AmmoInventory.AddCartridge(Player.rigManager.AmmoInventory.heavyAmmoGroup, ammoCount[2]);
        }

        public static void LevelInitialized(LevelInfo info)
        {
            MelonLoader.MelonLogger.Msg("Initialized Level");
            string barcodeName = info.barcode;
            if (barcodeName == "volx4.LabWorksBoneworksPort.Level.BoneworksRedactedChamber" || barcodeName == "volx4.LabWorksBoneworksPort.Level.Boneworks07CentralStation" || barcodeName == "volx4.LabWorksBoneworksPort.Level.Boneworks06Warehouse" || barcodeName == "volx4.LabWorksBoneworksPort.Level.Boneworks05Sewers" || barcodeName == "volx4.LabWorksBoneworksPort.Level.Boneworks04Runoff" || barcodeName == "volx4.LabWorksBoneworksPort.Level.Boneworks02Museum" || barcodeName == "volx4.LabWorksBoneworksPort.Level.Boneworks01Breakroom" || barcodeName == "volx4.LabWorksBoneworksPort.Level.Boneworks03Streets" || barcodeName == "volx4.LabWorksBoneworksPort.Level.Boneworks05Sewers")
            {
                MelonLogger.Msg("Level is Labworks");
                SetAmmo();
            }
            else
            {
                MelonLogger.Msg("Level ISNT Labworks");
                MelonLogger.Msg($"Barcode is: {barcodeName}");
            }
        }
    }
}
