using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holic.Object;

public class TestSceneManager : MonoBehaviour
{
	public GameObject prefab;
	public ushort size;

	// Use this for initialization
	void Start ()
	{
		ObjectPoolManager.instance.CreatePool(prefab, size);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			ObjectPoolManager.instance.ReuseObject(prefab, new Vector3(0, 1, 0), Quaternion.identity);
		}
	}
}
