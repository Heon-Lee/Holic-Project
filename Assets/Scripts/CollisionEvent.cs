using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
	public new string tag;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(tag))
		{
			Debug.Log(other.name);
			//other.GetComponent<Enemy>().OnHit(10);
		}
	}
}
