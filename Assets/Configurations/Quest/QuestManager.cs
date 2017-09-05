using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holic.Quest
{
	public static class QuestManager
	{
		public delegate void QuestHandler();
		public static event QuestHandler HandleEvent;

		public static QuestBase quest;

		public static void RunEvents()
		{
			Debug.Log("Running Events...");
			HandleEvent();
		}

		public static void AddNewQuestEvent(QuestHandler handler)
		{
			HandleEvent += handler;
		}
	}
}

