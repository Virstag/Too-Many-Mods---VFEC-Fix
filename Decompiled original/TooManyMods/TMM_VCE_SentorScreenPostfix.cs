using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Verse;
using VFEC.Senators;

namespace TooManyMods;

[HarmonyPatch(typeof(WorldComponent_Senators))]
[HarmonyPatch("AddSenatorsOption")]
public static class TMM_VCE_SentorScreenPostfix
{
	[HarmonyPostfix]
	public static void Postfix(ref IEnumerable<FloatMenuOption> __result)
	{
		List<FloatMenuOption> list = __result.ToList();
		FloatMenuOption floatMenuOption = list.LastOrDefault((FloatMenuOption opt) => opt.Label == "VFEC.Senators.Open".Translate());
		if (floatMenuOption != null && !TMM_VFECDefOf.VFEC_DramaAndComedy.PrerequisitesCompleted)
		{
			list.Remove(floatMenuOption);
		}
		__result = list;
	}
}
