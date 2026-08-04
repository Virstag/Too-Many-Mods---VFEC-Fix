using HarmonyLib;
using Verse;
using VFEC.Buildings;

namespace TooManyMods
{
    [HarmonyPatch(typeof(MapComponent_Beacon))]
    [HarmonyPatch("CanLightBeacon")]
    public static class TMMP_VCE_BeaconPostfix
    {
    	[HarmonyPrefix]
    	public static bool Prefix(MapComponent_Beacon __instance, ref bool __result)
    	{
    		if (TMM_VFECDefOf.VFEC_CarpeDiem.stages[0].baseMoodEffect == 3f)
    		{
    			return true;
    		}
    		int num = (int)AccessTools.Field(typeof(MapComponent_Beacon), "lastBeaconTick").GetValue(__instance);
    		if (num == -360000)
    		{
    			return true;
    		}
    		__result = num + 1800000 <= Find.TickManager.TicksGame;
    		return false;
    	}
    }
}
