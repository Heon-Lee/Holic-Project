using System.Collections.Generic;
using UnityEngine;
using Holic.UI;
using UnityEngine.UI;

public class DummyNPCTaylor : NPCObjectBase
{
	private Sprite spriteImage;

	protected override void Awake()
	{
		base.Awake();

		spriteImage = ResourceLoader.instance.TaylorSpriteImage;
	}

	private void Start()
	{
		attribute.SetNameTag("Taylor");
		attribute.SetClassTag("the alchemist");
	}

	public override void Interact()
	{
        Debug.Log("!!!@#!@#");
		SetDialogueData(attribute.nameTag, spriteImage);
		UserInterfaceManager.instance.PopDialogueUp();
	}

	public DummyNPCTaylor(GameObject gameObject) : base(gameObject)
	{

	}
}
