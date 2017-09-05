
using UnityEngine;
using Holic.Object;
using Holic.Quest;

public class DummyFireGolem : EnemyObjectBase
{
	public DummyFireGolem(GameObject gameObject) : base(gameObject)
	{

	}

	// Use this for initialization
	protected override void Start()
	{
		base.Start();

		tag = "Enemy";
		attribute.SetNameTag("Fire Golem, the Dummy!?");

		QuestManager.AddNewQuestEvent(OnEnemyWasDown);
		//QuestBase.HandleToEvent += OnEnemyWasDown;
	}

	public override void OnHurt()
	{
		if (true/*damage logic*/)
		{
			// when this was hurt,
			// do something...
		}

		if (true/*if this was down*/)
		{
			QuestManager.RunEvents();
		}

		Debug.Log("Destoried.");
		Destroy(gameObject, 1.0f);
	}

	public void OnEnemyWasDown()
	{
		Debug.Log("Enemy Was Down.");
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
