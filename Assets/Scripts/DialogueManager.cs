using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DialogueManager : MonoBehaviour
{
    private int outputIndex;
	public string textContents;

	[System.Serializable]
	public struct TalkBox
    {
        public string name;
        public string spriteNumber;
        public string talkText;
    }

	[SerializeField]
    public List<TalkBox> talkLists = new List<TalkBox>();

	private void Start()
	{
		LoadText(13);
    }

    public void TalkListClear()
    {
		talkLists.Clear();
    }

    public void LoadText(int dialogueIndex)
    {
        TextAsset textData = Resources.Load(GetDialoguePath(dialogueIndex)) as TextAsset;
		Debug.Log(textData.text);

        string[] loadStrArr = textData.text.Split('\n');
        string txt = null;
		Debug.Log(txt);

		for (int i = 0; i < loadStrArr.Length; i++)
            txt += loadStrArr[i];

        string[] splitNumAndTalk = txt.Split('*');
		Debug.Log(txt);
		txt = null;

        for (int i = 0; i < splitNumAndTalk.Length; i++)
            txt += splitNumAndTalk[i];

        string[] splitTalk = txt.Split('@');

		Debug.Log(txt);
		txt = null;

        for (int q = 0; q < splitTalk.Length; q++)
            txt += splitTalk[q];

		Debug.Log(txt);

		for (int i = 1; i < splitTalk.Length; i++)
        {
            TalkBox talkBox = new TalkBox();
            string strAdd = null;
            for (int j = 0; j < splitTalk[i].Length; j++)
                strAdd += splitTalk[i][j];

            string[] split = strAdd.Split('#');
			talkBox.name = split[1];
			talkBox.spriteNumber = split[2];
			talkBox.talkText = split[3];

			Debug.Log(talkBox.talkText);
			talkLists.Add(talkBox);
        }
    }

    private string GetDialoguePath(int dialogueIndex)
    {
		string indexStr = dialogueIndex.ToString();

		// e.x) "/13_talk"
		return dialogueIndex.ToString() + "_talk";
	}
}
