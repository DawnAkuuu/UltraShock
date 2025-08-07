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


            // Initialize Harmony
            var harmony = new Harmony("com.dawn.shockmod");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(NewMovement), "GetHurt")]
        class GetHurtPatch 
        {
            static void Postfix(NewMovement __instance)
            {
                if (__instance.hp <= 0)
                {
                    try
                    {
                        File.WriteAllText(@"C:\Users\{USERNAME}\Documents\ultrakill_event.txt", "PlayerDied");
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
