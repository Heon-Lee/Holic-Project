using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holic.Object;
using Holic.Quest;

public class PlayerObject : ObjectBase
{
	[SerializeField]
	protected ObjectAttributeBase attribute = new PlayerAttribute();

	public QuestBase quest;

	protected override void Awake()
	{
		base.Awake();
	}

	public PlayerObject(GameObject gameObject) : base(gameObject)
	{

	}

	public override void OnObjectInitiated()
	{

	}

	public override void OnObjectReused()
	{

	}

	public override void PlayAudio(Sound sound)
	{

	}
}

