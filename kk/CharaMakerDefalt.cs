// #name CharaMaker Defalt
// #desc setup default options in CharaMaker
// #proc_filter Koikatu.exe
// #author Madevil
// v20.05.17.1

using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
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
			GameObject.Find("FrontUIGroup/CvsDraw/Top/tglBlink/imgTglCol").GetComponent<Toggle>().isOn = true;
			GameObject.Find("FrontUIGroup/CvsDraw/Top/grpMouthPtn/ddMouthPtn").GetComponent<TMP_Dropdown>().value = 2;
			GameObject.Find("FrontUIGroup/CvsDraw/Top/grpEyesPtn/ddEyesPtn").GetComponent<TMP_Dropdown>().value = 2;
			GameObject.Find("FrontUIGroup/CvsDraw/Top/rbClothesState/imgRbCol01").GetComponent<Toggle>().isOn = true;
			GameObject.Find("FrontUIGroup/CvsDraw/Top/rbBackType/imgRbCol01").GetComponent<Toggle>().isOn = true;
		}
	}
}
