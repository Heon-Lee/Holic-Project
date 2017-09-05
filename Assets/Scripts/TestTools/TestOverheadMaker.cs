using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holic.Game;

public class TestOverheadMaker : MonoBehaviour
{
	[Range(0, 5000)]
	public int overhead;
	public GameObject dummyPrefab;

	float startTime;
	float endTime;

	private void Awake()
	{
		GameObject go = Instantiate(dummyPrefab);
		go.name = dummyPrefab.GetInstanceID().ToString();
		GameManager.RunInitializationFunction += OnGameLoaded;

		int index;

		for (index = 0; index < overhead; index++)
		{
			//Debug.Log("Current: " + index);
			Instantiate(GameObject.Find(dummyPrefab.GetInstanceID().ToString()));
		}
	}

	public void OnGameLoaded()
	{

	}
}
