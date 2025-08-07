using BepInEx;
using UnityEngine;
using ULTRAKILL;
using HarmonyLib;
using System.IO;


namespace ShockMod
{
    [BepInPlugin("com.dawn.shockmod", "Shock Mod", "1.0.0")]
    public class Class1 : BaseUnityPlugin
    {

        void Awake()
        {
            // This method is called when the plugin is loaded
            Logger.LogInfo("Shock Mod Loaded!");
            Logger.LogInfo("This mod is writing ultrakill_event.txt to " + Application.persistentDataPath);



            // Initialize Harmony
            var harmony = new Harmony("com.dawn.shockmod");
            harmony.PatchAll();
        }

        // Patch the GetHurt() function in ultrakill
        [HarmonyPatch(typeof(NewMovement), "GetHurt")]
        class GetHurtPatch 
        {
            static void Postfix(NewMovement __instance)
            {
                if (__instance.hp <= 0)
                {
                    try
                    {
                        // Write PlayerDied to a folder in the application data path.
                        File.WriteAllText(Application.persistentDataPath + @"/ultrakill_event.txt", "PlayerDied");
                    }
                    catch (IOException ex)
                    {
                        Debug.LogError($"ShockMod file write error: {ex.Message}");
                    }
                }
            }
        }
    }
}
