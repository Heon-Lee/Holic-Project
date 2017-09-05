using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holic.Object
{
	public abstract class EnemyObjectBase : ObjectBase
	{
		[SerializeField]
		protected EnemyAttribute _attribute = new EnemyAttribute();

		public EnemyAttribute attribute
		{
			get
			{
				return _attribute;
			}
		}

		protected override void Awake()
		{
			base.Awake();
		}

		public EnemyObjectBase(GameObject gameObject) : base(gameObject)
		{

		}

		protected virtual void Start()
		{
			tag = "Enemy";
		}

		public abstract void OnHurt();
	}
}

