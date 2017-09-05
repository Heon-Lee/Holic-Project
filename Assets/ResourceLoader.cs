using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceLoader : MonoBehaviour
{
	public static ResourceLoader instance = null;

	public string imagePath;

	public Sprite TaylorSpriteImage;

	[SerializeField]
	private Image _portrait;
	public Image portrait
	{
		get
		{
			return _portrait;
		}
	}

	private void Awake()
	{
		instance = this;
		DontDestroyOnLoad(gameObject);

		TaylorSpriteImage = Resources.Load<Sprite>(imagePath + "Taylor");

		//Resources.Load<GameObject>(imagePath + "PortraitPrefab").GetComponent<Image>().sprite = null;
	}
}
