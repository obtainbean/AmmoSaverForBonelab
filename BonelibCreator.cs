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

            labworksAmmoSaverCategory.CreateFunctionElement("Reset Ammo", Color.yellow, () => AmmoFunctions.ClearAmmo());

            category = MelonPreferences.CreateCategory("Labworks_Ammo_Saver");
            ammo = category.CreateEntry<List<int>>("Ammo", null);
        }

        public static MelonPreferences_Entry<List<int>> ammo;
    }
}
