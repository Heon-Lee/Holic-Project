using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Holic.UI
{
	using DialoguePanel = GameObject;
	using DialogueImage = Image;
	using DialogueText = Text;

	public class UserInterfaceManager : MonoBehaviour
	{
		public static UserInterfaceManager instance = null;

		public DialoguePanel dialoguePanel;
		public DialogueText dialogueMessage;
		public DialogueImage dialogueImage;
		public Text dialogueNameTag;

		public Image portrait;

		private void Awake()
		{
			instance = this;

			dialoguePanel = GameObject.Find("DialogueLayout");
			dialogueMessage = dialoguePanel.GetComponentInChildren<DialogueText>();
			dialogueImage = dialoguePanel.transform.FindChild("DialoguePanel").GetComponent<DialogueImage>();
			portrait = GameObject.Find("Portrait").GetComponent<Image>();
			dialogueNameTag = dialoguePanel.transform.FindChild("NameTag").GetComponentInChildren<Text>();
			dialoguePanel.SetActive(false);
		}

		public void PopDialogueUp()
		{
			dialoguePanel.SetActive(true);
		}
	}
}

