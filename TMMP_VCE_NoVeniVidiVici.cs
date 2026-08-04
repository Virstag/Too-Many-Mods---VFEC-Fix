using System.Collections.Generic;
using HarmonyLib;
using Verse;
using VFEC.Perks.Workers;

namespace TooManyMods
{
    [HarmonyPatch(typeof(VeniVidiVici))]
    [HarmonyPatch("AddGizmo")]
    public static class TMMP_VCE_NoVeniVidiVici
    {
    	[HarmonyPrefix]
    	public static bool Prefix(IEnumerable<Gizmo> gizmos, ref IEnumerable<Gizmo> __result)
    	{
    		if (TMM_VFECDefOf.VFEC_CarpeDiem.stages[0].baseMoodEffect == 3f)
    		{
    			return true;
    		}
    		__result = gizmos;
    		return false;
    	}
    }
}
