using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holic.Animation;

public class PlayerAvatarController : AvatarControllerBase
{
	private AnimatorStateInfo currentAnimatorState;

	protected bool isComboValid;
	protected bool isTimerDone;
	private int comboCount = 0;
	private const int BaseLayer = 0;
	

	public float rangeAllowedToControl = 0.5f; // half

	public int asd = Animator.StringToHash("");

	public override void SetState(State newState)
	{
		isThereNewState = true;
		state = newState;
		
		avatar.SetInteger(BaseState, (int)state);
	}

	public void OnComboAttackDone()
	{
		Debug.Log("OnComboAttackDone");
		avatar.SetInteger("Combo", 0);
		avatar.SetInteger(BaseState, (int)State.Idle);
	}

	public void TryAttack()
	{
		switch (state)
		{
			case State.Idle:
				SetState(State.ComboAttack1);
				break;
			case State.ComboAttack1:
				SetState(State.ComboAttack2);
				break;
			case State.ComboAttack2:
				SetState(State.ComboAttack3);
				break;
			case State.ComboAttack3:
				SetState(State.Idle);
				break;
			case State.ComboCancel:
				break;
			default:
				break;
		}
	}

	private bool IsAnimationDone(AnimatorStateInfo animatorStateInfo)
	{
		const float AnimationCompletedTime = 0.7f;
		if (animatorStateInfo.normalizedTime >= AnimationCompletedTime)
		{
			return true;
		}

		else
		{
			return false;
		}
	}

	private bool IsComboAnimationValid(AnimatorStateInfo animatorStateInfo, float validTime)
	{
		if (animatorStateInfo.normalizedTime > validTime)
		{
			return true;
		}

		else
		{
			return false;
		}
	}

	private void UpdateAnimationState(AnimatorStateInfo animatorStateInfo)
	{
		float animationProgress = animatorStateInfo.normalizedTime;
		const int MaximumComboCount = 3;

		// allow to input to half
		if (rangeAllowedToControl < animationProgress && comboCount < MaximumComboCount)
		{
			avatar.SetInteger("Combo", comboCount);
			Debug.Log("Combo! : " + comboCount);
		}

		else
		{
			//avatar.SetInteger("State", (int)State.Idle);
			//Debug.Log("Combo-time over. Reset");
		}

		if (comboCount == MaximumComboCount)
		{
			comboCount = 0;
		}

		else
		{
			++comboCount;
		}
	}

	protected override IEnumerator Attack() // : final
	{
		do
		{
			yield return null;

			//const float ValidTime = 0.7f;
			//currentAnimatorState = avatar.GetCurrentAnimatorStateInfo(BaseLayer);
			//if (IsComboAnimationValid(currentAnimatorState, ValidTime))
			//{
			//	Debug.Log("Ok, You can try to combo-attack.");
			//}

			//else
			//{
			//	Debug.Log("Not Valid!");
			//}
		}

		while (true);
	}

	private IEnumerator ComboAttack1()
	{
		do
		{
			yield return null;

			if (IsAnimationDone(avatar.GetCurrentAnimatorStateInfo(BaseLayer))
				&& avatar.GetCurrentAnimatorStateInfo(BaseLayer).IsName("ComboAttack1"))
			{
				if (IsComboAnimationValid(avatar.GetCurrentAnimatorStateInfo(BaseLayer), 0.3f))
				{
					SetState(State.Idle);
				}
			}
		}

		while (!isThereNewState);
	}

	private IEnumerator ComboAttack2()
	{
		do
		{
			yield return null;

			if (IsAnimationDone(avatar.GetCurrentAnimatorStateInfo(BaseLayer))
				&& avatar.GetCurrentAnimatorStateInfo(BaseLayer).IsName("ComboAttack2"))
			{
				if (IsComboAnimationValid(avatar.GetCurrentAnimatorStateInfo(BaseLayer), 0.3f))
				{
					SetState(State.Idle);
				}
			}
		}

		while (!isThereNewState);
	}

	private IEnumerator ComboAttack3()
	{
		do
		{
			yield return null;

			if (IsAnimationDone(avatar.GetCurrentAnimatorStateInfo(BaseLayer))
				&& avatar.GetCurrentAnimatorStateInfo(BaseLayer).IsName("ComboAttack3"))
			{
				if (IsComboAnimationValid(avatar.GetCurrentAnimatorStateInfo(BaseLayer), 0.3f))
				{
					SetState(State.Idle);
				}
			}
		}

		while (!isThereNewState); // if start, always check it done.
	}

	private IEnumerator ComboCancel()
	{
		do
		{
			yield return null;

			//if (true)
			//{
			//	SetState(State.Idle);
			//}
		}

		while (!isThereNewState);
	}

	private IEnumerator Timer(float time)
	{
		yield return new WaitForSeconds(time);
		isTimerDone = true;
	}

	private void StartTimer(float time)
	{
		if (!isTimerDone)
		{
			StartCoroutine(Timer(time));
		}
	}

	private void StopTimer()
	{
		if (isTimerDone)
		{
			isTimerDone = false;
			StopCoroutine("Timer");
		}
	}

	protected override IEnumerator UpdatePerFrame()
	{
		while (true)
		{
			isThereNewState = false;

			yield return StartCoroutine(state.ToString(), null);
		}
	}
}
