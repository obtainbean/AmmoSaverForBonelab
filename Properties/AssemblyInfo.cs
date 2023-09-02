using System.Reflection;
using Labworks_Ammo_Saver;
using MelonLoader;

[assembly: AssemblyTitle(Labworks_Ammo_Saver.Main.Description)]
[assembly: AssemblyDescription(Labworks_Ammo_Saver.Main.Description)]
[assembly: AssemblyCompany(Labworks_Ammo_Saver.Main.Company)]
[assembly: AssemblyProduct(Labworks_Ammo_Saver.Main.Name)]
[assembly: AssemblyCopyright("Developed by " + Labworks_Ammo_Saver.Main.Author)]
[assembly: AssemblyTrademark(Labworks_Ammo_Saver.Main.Company)]
[assembly: AssemblyVersion(Labworks_Ammo_Saver.Main.Version)]
[assembly: AssemblyFileVersion(Labworks_Ammo_Saver.Main.Version)]
[assembly: MelonInfo(typeof(Labworks_Ammo_Saver.Main), Labworks_Ammo_Saver.Main.Name, Labworks_Ammo_Saver.Main.Version, Labworks_Ammo_Saver.Main.Author, Labworks_Ammo_Saver.Main.DownloadLink)]
[assembly: MelonColor(System.ConsoleColor.White)]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Stress Level Zero", "BONELAB")]