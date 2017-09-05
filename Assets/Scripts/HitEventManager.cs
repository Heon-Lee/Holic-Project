using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holic.Animation
{
	public class HitEventManager : MonoBehaviour
	{
		public new Collider collider;

		[Header("Find Option*")]
		[Tooltip("If this was allowed, It would make some overhead.")]
		public bool isAllowedToAutoSearch;
		public string searchingName;

		private void Start()
		{
			if (isAllowedToAutoSearch)
			{
				collider = GameObject.Find(searchingName).GetComponent<Collider>();
			}
		}

		public void SetEnabled()
		{
			collider.enabled = true;
		}

		public void SetDisabled()
		{
			collider.enabled = false;
		}
	}
}
