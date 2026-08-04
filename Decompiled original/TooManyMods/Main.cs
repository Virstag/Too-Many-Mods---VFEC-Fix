using System.Reflection;
using HarmonyLib;
using Verse;

namespace TooManyMods;

[StaticConstructorOnStartup]
public static class Main
{
	static Main()
	{
		Harmony harmony = new Harmony("com.harmony.rimworld.example");
		harmony.PatchAll(Assembly.GetExecutingAssembly());
	}
}
