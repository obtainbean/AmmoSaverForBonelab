using BoneLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labworks_Ammo_Saver
{
    public static class AmmoFunctions
    {
        public static void SaveAmmo()
        {
            List<int> ammoCount = new List<int>();
            ammoCount.Add(Player.rigManager.AmmoInventory.GetCartridgeCount("light"));
            ammoCount.Add(Player.rigManager.AmmoInventory.GetCartridgeCount("medium"));
            ammoCount.Add(Player.rigManager.AmmoInventory.GetCartridgeCount("heavy"));

            BonelibCreator.ammo.Value = ammoCount;
            BonelibCreator.ammo.Save();
        }

        public static void ClearAmmo()
        {
            Player.rigManager.AmmoInventory.ClearAmmo();

            BonelibCreator.ammo.Value[0] = 0;
            BonelibCreator.ammo.Value[1] = 0;
            BonelibCreator.ammo.Value[2] = 0;

            BonelibCreator.ammo.Save();
        }

        public static void SetAmmo()
        {
            List<int> ammoCount = BonelibCreator.ammo.Value;

            Player.rigManager.AmmoInventory.ClearAmmo();

            Player.rigManager.AmmoInventory.AddCartridge(Player.rigManager.AmmoInventory.lightAmmoGroup, ammoCount[0]);
            Player.rigManager.AmmoInventory.AddCartridge(Player.rigManager.AmmoInventory.mediumAmmoGroup, ammoCount[1]);
            Player.rigManager.AmmoInventory.AddCartridge(Player.rigManager.AmmoInventory.heavyAmmoGroup, ammoCount[2]);
        }
    }
}
