using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holic.Object
{
	public enum Sound
	{
		Idle,
		Run,
		Attack,
		Dead
	}

	[RequireComponent(typeof(AudioSource))]
	public abstract class ObjectBase : MonoBehaviour
	{
		[HideInInspector]
		public new Transform transform;

		protected AudioSource audioSource { get; set; }
		protected List<AudioClip> audioClips { get; set; }
		
		public ObjectBase(GameObject gameObject)
		{

		}

		protected virtual void Awake()
		{
			transform = GetComponent<Transform>();
			audioSource = GetComponent<AudioSource>();

			Holic.Game.GameManager.RunInitializationFunction += OnObjectInitiated;
		}

		public abstract void OnObjectInitiated();
		public abstract void PlayAudio(Sound sound);
		public abstract void OnObjectReused();

		public void Instantiate(GameObject origin, Vector3 position, Quaternion rotation)
		{

		}

		protected void Destory()
		{
			gameObject.SetActive(false);
		}

		protected void Destory(float time)
		{
			StartCoroutine(DestoryAfterTime(gameObject, time));
		}

		/// <summary>
		/// [ObjectBaseOverride] Deactivates the GameObject.
		/// </summary>
		/// <param name="obj">The object to deactivate.</param>
		protected void Destroy(ObjectBase obj)
		{
			obj.gameObject.SetActive(false);
		}

		/// <summary>
		/// [ObjectBaseOverride] Deactivates the GameObject.
		/// </summary>
		/// <param name="obj">The object to deactivate.</param>
		protected void Destroy(GameObject gameObject)
		{
			gameObject.SetActive(false);
		}

		protected void Destroy(GameObject gameObject, float time)
		{
			StartCoroutine(DestoryAfterTime(gameObject, time));
		}

		protected void DestroyGameObject(GameObject obj)
		{
			UnityEngine.Object.Destroy(obj);
		}

		protected IEnumerator DestoryAfterTime(GameObject go, float time)
		{
			yield return new WaitForSeconds(time);

			go.SetActive(false);
		}
	}
}
