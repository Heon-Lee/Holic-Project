
using UnityEngine;

[System.Serializable]
public class CombatObjectAttribute : ObjectAttributeBase
{
	// attributes for combat
	[Header("Private Data*")]
	[SerializeField] protected int maximumHitPoint;
	[SerializeField] protected int currentHitPoint;
	[SerializeField] protected int _damage;

	public override void SetNameTag(string nameTag)
	{
		_nameTag = nameTag;
	}

	public int maxHitPoint
	{
		get
		{
			return maximumHitPoint;
		}
	}

	public int curHitPoint
	{
		get
		{
			return currentHitPoint;
		}
	}

	public int damage
	{
		get
		{
			return _damage;
		}
	}

	public void SetMaximumHitPoint(int value)
	{
		maximumHitPoint = value;
	}

	public void SetCurrentHitPoint(int value)
	{
		currentHitPoint = value;
	}

	public void SetDamage(int value)
	{
		_damage = value;
	}
}
