// #name Refresh Chara
// #desc ability to refresh character in CharaMaker
// #proc_filter Koikatu.exe
// #author Madevil
// v20.05.17.2

using UnityEngine;
using KKAPI.Maker;

public static class ScriptLoaderRefreshChara
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

		void Update()
		{
			if (Input.GetKeyDown(ScriptLoaderRefreshChara.triggerKey))
				RefreshChara();
		}

		void RefreshChara()
		{
			if (MakerAPI.InsideAndLoaded)
			{
				MakerAPI.GetCharacterControl().ChangeCoordinateTypeAndReload(false);
//				BepInEx.Logging.Logger.LogDebug("Character Refreshed");
			}
		}
	}
}
