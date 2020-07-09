// #name CustomSelectListCtrl OnPointerClick HarmonyPostfix
// #desc display selected item ResolveInfo
// #proc_filter Koikatu.exe
// #author Madevil
// v20.06.29.2

using System;
using BepInEx.Harmony;
using ChaCustom;
using HarmonyLib;
using Sideloader.AutoResolver;
using UnityEngine;

public static class ScriptLoaderCustomSelectListCtrl
{
	public static HarmonyLib.Harmony instance;

	public static void Main()
	{
		instance = HarmonyWrapper.PatchAll(typeof(Hooks));
	}

	public static void Unload()
	{
		instance.UnpatchAll(instance.Id);
		instance = null;
	}

	internal static class Hooks
	{
		[HarmonyPostfix, HarmonyPatch(typeof(CustomSelectListCtrl), "OnPointerClick")]
		internal static void CustomSelectListCtrlPostfix(CustomSelectListCtrl __instance, GameObject obj)
		{
			if (null == obj)
				return;
			CustomSelectInfoComponent component = obj.GetComponent<CustomSelectInfoComponent>();
			if (null == component)
				return;
			if (!component.tgl.interactable)
				return;

			if (__instance.onChangeItemFunc != null)
			{
				if (component.info.index >= UniversalAutoResolver.BaseSlotID)
				{
					ResolveInfo Info = UniversalAutoResolver.TryGetResolutionInfo((ChaListDefine.CategoryNo) component.info.category, component.info.index);
					if (Info != null)
						BepInEx.Logging.Logger.LogWarning($"[CustomSelectListCtrlPostfix][{Info.GUID}][{(int) Info.CategoryNo}][{Info.CategoryNo}][{Info.Slot}][{Info.LocalSlot}]");
				}
				else
					BepInEx.Logging.Logger.LogWarning($"[CustomSelectListCtrlPostfix][hardmod][{(ChaListDefine.CategoryNo) component.info.category}][{component.info.category}][{component.info.index}]");
			}
		}
	}
}