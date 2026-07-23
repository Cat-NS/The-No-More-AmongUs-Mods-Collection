using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace NoMoreAFK
{
    [BepInPlugin("com.yourname.nomoreafk", "No More AFK", "1.0.0")]
    public class Plugin : BasePlugin
    {
        public override void Load()
        {
            Harmony.CreateAndPatchAll(typeof(AFKPatch));
            Log.LogInfo("NoMoreAFK загружен (IL2CPP)");
        }
    }

    [HarmonyPatch(typeof(AmongUsClient), "CheckAFK")]
    public static class AFKPatch
    {
        public static bool Prefix(AmongUsClient __instance)
        {
            // Попробуй isHost (с маленькой) или AmHost, проверь в декомпиляторе
            return !__instance.AmHost; // замени на правильное имя
        }
    }
}