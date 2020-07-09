// #name InitIKTarget HarmonyPostfix
// #desc patch wrong targets on IK shoulders
// #proc_filter StudioNEOV2.exe
// #author Madevil
// v20.07.07.1

using BepInEx.Harmony;
using HarmonyLib;
using UnityEngine;
using Studio;
using RootMotion.FinalIK;

public static class ScriptLoaderInitIKTargetHarmonyPostfix
{
	public static HarmonyLib.Harmony instance;

	public static void Main()
	{
		instance = HarmonyLib.Harmony.CreateAndPatchAll(typeof(Hooks));
	}

	public static void Unload()
	{
		instance.UnpatchAll(instance.Id);
		instance = null;
	}

	internal static class Hooks
	{
		[HarmonyPostfix, HarmonyPatch(typeof(AddObjectAssist), "InitIKTarget")]
		public static void InitIKTarget(OCIChar _ociChar, bool _addInfo)
		{
			IKSolverFullBodyBiped solver = _ociChar.finalIK.solver;
			solver.rightShoulderEffector.target.name = "f_t_shoulder_R(work)";
			solver.leftShoulderEffector.target.name = "f_t_shoulder_L(work)";
			BepInEx.Logging.Logger.LogWarning("IK patch applied for: " + solver.rightShoulderEffector.target.name);
			BepInEx.Logging.Logger.LogWarning("IK patch applied for: " + solver.leftShoulderEffector.target.name);
		}
	}
}
