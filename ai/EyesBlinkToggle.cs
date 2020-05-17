// #name EyesBlinkToggle
// #desc toggle character blinking in CharaMaker
// #proc_filter AI-Syoujyo.exe
// #author Madevil
// v20.05.17.1

using UnityEngine;
using UnityEngine.UI;
using System;
using KKAPI.Maker;

public static class ScriptLoaderEyesBlinkToggle
{
	private const KeyCode triggerKey = KeyCode.F5;

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

		void Update()
		{
			if (Input.GetKeyDown(ScriptLoaderEyesBlinkToggle.triggerKey) && MakerAPI.InsideAndLoaded)
			{
				var chaCtrl = MakerAPI.GetCharacterControl();
				bool blinkFlag = chaCtrl.chaFile.status.eyesBlink;
				chaCtrl.ChangeEyesBlinkFlag(!blinkFlag);
				Singleton<Manager.Resources>.Instance.SoundPack.Play(AIProject.SoundPack.SystemSE.OK_L);
			}
		}

		private void MakerFinishedLoading(object sender, EventArgs e)
		{
			MakerAPI.GetCharacterControl().ChangeEyesBlinkFlag(false);
		}
	}
}
