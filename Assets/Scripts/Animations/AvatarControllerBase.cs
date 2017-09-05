using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holic.Animation
{
	public enum State
	{
		Idle,
		Move,
		Attack,
		Hurt,
		Dead,
		ComboAttack1,
		ComboAttack2,
		ComboAttack3,
		ComboCancel
	}

	public abstract class AvatarControllerBase : MonoBehaviour
	{
		protected State state;
		protected string BaseState = "State";

		protected Animator _avatar;
		public Animator avatar { get { return _avatar; } }

		protected bool isThereNewState;

		protected virtual void Awake()
		{
			_avatar = GetComponent<Animator>();
			state = State.Idle;
		}

		protected virtual void OnEnable()
		{
			StartCoroutine(UpdatePerFrame());
		}

		protected virtual void OnDisable()
		{
			StopCoroutine(UpdatePerFrame());
		}

		public virtual void SetState(string stateParameter, State newState)
		{
			isThereNewState = true;
			state = newState;

			avatar.SetInteger(stateParameter, (int)state);
		}

		public virtual void SetState(State newState)
		{
			isThereNewState = true;
			state = newState;

			avatar.SetInteger(BaseState, (int)state);
		}

		// naive function-call. this function uses unnecessary force-casting.
		public virtual void SetState(int newState)
		{
			isThereNewState = true;
			state = (State)newState;

			avatar.SetInteger(BaseState, (int)state);
		}

		protected virtual IEnumerator Idle()
		{
			do
			{
				yield return null;

			}

			while (!isThereNewState);
		}

		protected virtual IEnumerator Attack()
		{
			do
			{
				yield return null;


			}

			while (!isThereNewState);
		}

		protected virtual IEnumerator UpdatePerFrame()
		{
			while (true)
			{
				isThereNewState = false;

				yield return StartCoroutine(state.ToString(), null);
			}
		}
	}
}
