using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestStickRotation : MonoBehaviour
{
	public Image image;
	public float rot;
	Quaternion q = new Quaternion();
	// Use this for initialization
	void Start ()
	{
		//StartCoroutine(Rotate());
	}

	private void Update()
	{
		q.z += 10.0f;
		image.rectTransform.rotation = q;
		image.rectTransform.Rotate(0, 0, q.z);
	}

	IEnumerator Rotate()
	{
		while (true)
		{

		}
	}
}
