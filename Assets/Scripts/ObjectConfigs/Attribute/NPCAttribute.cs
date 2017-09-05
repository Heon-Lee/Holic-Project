
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NPCAttribute : ObjectAttributeBase
{
	[SerializeField]
	private string _classTag;
	private Image _portrait;

	public string classTag
	{
		get
		{
			return _classTag;
		}
	}

	public Image portrait
	{
		get
		{
			return _portrait;
		}
	}

	public override void SetNameTag(string nameTag)
	{
		_nameTag = nameTag;
	}

	public void SetClassTag(string value)
	{
		_classTag = value;
	}

	public void SetPortraitImage(Image portrait)
	{
		Debug.LogWarning("It was deprecated.");
	}
}
