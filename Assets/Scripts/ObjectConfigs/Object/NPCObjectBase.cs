using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holic.Object;
using Holic.UI;
using UnityEngine.UI;

public abstract class NPCObjectBase : ObjectBase
{
	[SerializeField]
	protected NPCAttribute _attribute = new NPCAttribute();

	[SerializeField]
	protected Sprite sprite;

	private Image uiPortraitImage;
	protected Image portraitImage
	{
		get
		{
			return uiPortraitImage;
		}
	}

	public NPCAttribute attribute
	{
		get
		{
			return _attribute;
		}
	}

	public Sprite portraitSprite
	{
		get
		{
			return sprite;
		}
	}

	public abstract void Interact();

	protected override void Awake()
	{
		base.Awake();

		uiPortraitImage = UserInterfaceManager.instance.portrait;
	}

	public NPCObjectBase(GameObject gameObject) : base(gameObject)
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

	protected void SetDialogueData(string nameTag, Sprite spriteImage)
	{
		UserInterfaceManager.instance.dialogueNameTag.text = nameTag;
		uiPortraitImage.sprite = spriteImage;
	}
}
