using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Holic.Game
{
	public delegate void ProgressDelegate(float progress);

	public class GameManager : MonoBehaviour
	{
		public delegate void InstanceHandler();
		public static event InstanceHandler RunInitializationFunction;

		public float timeScale { get; set; }
		public string gameVersion;
		public ushort currentState;

		public UnityEngine.UI.Text __TEXT;

		private void Awake()
		{
			DontDestroyOnLoad(gameObject);
		}

		public static void GettingStarted()
		{
			RunInitializationFunction();
		}

		public void OnTapButtonClicked(string sceneName)
		{
			StartCoroutine(LoadSceneAsync(sceneName, OnLoadLevelProgressUpdate));
		}

		public static IEnumerator LoadSceneAsync(string sceneName, ProgressDelegate dProgress)
		{
			AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
			//asyncOperation.allowSceneActivation = false;
			
			while (!async.isDone)
			{
				dProgress(async.progress);
				async.allowSceneActivation = async.progress > 0.85f;

				yield return null;
			}
		}

		private void OnLoadLevelProgressUpdate(float progress)
		{
			__TEXT.text = string.Format("(LOADING... {0}%)", (progress * 100.0f) + 9.9f);
		}
	}
}

