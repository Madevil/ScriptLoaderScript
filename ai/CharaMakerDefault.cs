// #name CharaMaker Default
// #desc setup default options in CharaMaker
// #proc_filter AI-Syoujyo.exe
// #author Madevil
// v20.05.17.1

using UnityEngine;
using UnityEngine.UI;
using System;
using KKAPI.Maker;

public static class ScriptLoaderCharaMakerDefault
{
	private static GameObject gameObject;

	public static void Main()
	{
		gameObject = new GameObject();
		gameObject.AddComponent<GameObjectMain>();
	}

	public static void Unload()
	{
		UnityEngine.Object.Destroy(gameObject);
		gameObject = null;
	}

	class GameObjectMain : MonoBehaviour
	{
		void Awake()
		{
			DontDestroyOnLoad(this);
		}

		void Main()
		{
			MakerAPI.MakerFinishedLoading += MakerFinishedLoading;
		}

		private void MakerFinishedLoading(object sender, EventArgs e)
		{
			GameObject.Find("CharaCustom/CustomControl/CanvasDraw/DrawWindow/dwCoorde/clothes/items/tgl01").GetComponent<Toggle>().isOn = true;
		}
	}
}
