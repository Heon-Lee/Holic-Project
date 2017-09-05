using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ObjectAttributeBase
{
	[SerializeField] protected string _nameTag;
	[SerializeField] protected float _movingSpeed;

	public float movingSpeed
	{
		get
		{
			return _movingSpeed;
		}
	}

	public string nameTag
	{
		get
		{
			return _nameTag;
		}
	}

	public void SetMovingSpeed(float value)
	{
		_movingSpeed = value;
	}

	public abstract void SetNameTag(string nameTag);
}
