using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holic.Object
{
	using PoolManager = ObjectPoolManager;

	public class ObjectPoolManager : MonoBehaviour
	{
		public static PoolManager instance = null;

		public Dictionary<int, Queue<ObjectInstance>> poolDictionary =
			new Dictionary<int, Queue<ObjectInstance>>();

		private void Awake()
		{
			instance = this;
			//DontDestroyOnLoad(gameObject);
		}

		public void CreatePool(GameObject prefab, ushort size)
		{
			int poolKey = prefab.GetInstanceID();

			if (prefab == null)
			{
				Debug.LogError("ObjectPoolError - UnassignedReference: 'GameObject prefab' not been assigned.");
				return;
			}

			GameObject poolContainer = new GameObject(prefab.name + " Container");
			poolContainer.transform.parent = transform;

			if (!poolDictionary.ContainsKey(poolKey))
			{
				poolDictionary.Add(poolKey, new Queue<ObjectInstance>());

				for (ushort i = 0; i < size; i++)
				{
					ObjectInstance newObject = new ObjectInstance(Instantiate(prefab) as GameObject);
					poolDictionary[poolKey].Enqueue(newObject);
					newObject.SetParent(poolContainer.transform);
				}
			}
		}

		public void ReuseObject(GameObject origin, Vector3 position, Quaternion rotation)
		{
			int poolKey = origin.GetInstanceID();

			if (poolDictionary.ContainsKey(poolKey))
			{
				ObjectInstance pooledObject = poolDictionary[poolKey].Dequeue();
				poolDictionary[poolKey].Enqueue(pooledObject);
				pooledObject.Reuse(position, rotation);
			}
		}

		public class ObjectInstance
		{
			public GameObject gameObject;
			public Transform transform;

			public bool isObjectBaseComponent;
			public ObjectBase objectBase;

			public ObjectInstance(GameObject gameObject)
			{
				this.gameObject = gameObject;
				this.transform = gameObject.transform;
				gameObject.SetActive(false);

				if (gameObject.GetComponent<ObjectBase>())
				{
					isObjectBaseComponent = true;
					objectBase = gameObject.GetComponent<ObjectBase>();
				}
			}

			public void Reuse(Vector3 position, Quaternion rotation)
			{
				if (isObjectBaseComponent)
				{
					objectBase.OnObjectReused();
				}

				gameObject.SetActive(true);
				transform.position = position;
				transform.rotation = rotation;
			}

			public void SetParent(Transform parent)
			{
				transform.SetParent(parent);
			}
		}
	}
}

