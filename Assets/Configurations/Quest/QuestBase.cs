using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holic.Quest
{
	public abstract class QuestBase : MonoBehaviour
	{
		public List<Quest> progressingQuests;
		public List<Quest> doneQuests;
		
		private void Awake()
		{
			
		}

		public Quest GetQuest()
		{
			return progressingQuests[0];
		}

		public void OnEventHandled()
		{

		}

		public void OnHuntingQuest()
		{
			
		}

		public class Quest
		{
			private int level;
			private string str;

			public Quest()
			{

			}

			public Quest(int level, string str)
			{
				this.level = level;
				this.str = str;
			}
		}
	}
}

