using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holic.Object;
using Holic.Animation;

[RequireComponent(typeof(PlayerAvatarController))]
public class TestPlayerController : MonoBehaviour
{
	[Range(0.5f, 10.0f)]
	public float speed;

	private PlayerAvatarController avatarController;

	private void Start()
	{
		avatarController = GetComponent<PlayerAvatarController>();
	}

	// Update is called once per frame
	private void Update ()
	{
		OnArrowKeyCodeCalled();

		if (Input.GetKeyDown(KeyCode.Q))
		{
			Debug.Log("Compare the quest...");
		}

		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			avatarController.TryAttack();
		}

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				GameObject hitObject = hit.collider.gameObject;

				if (hitObject.CompareTag("Enemy"))
				{
					EnemyObjectBase enemy = hitObject.GetComponent<EnemyObjectBase>();
					//Debug.Log("You had selected " + enemy.attribute.nameTag);
					enemy.OnHurt();
				}

				if (hitObject.CompareTag("NPC"))
				{
					NPCObjectBase npc = hitObject.GetComponent<NPCObjectBase>();
					npc.Interact();
					//Debug.Log("You had selected " + npc.attribute.nameTag + ", the " + npc.attribute.classTag);
				}
			}
		}
	}

	private void OnArrowKeyCodeCalled()
	{
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector3.left * speed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.back * speed * Time.deltaTime);
		}
	}
}
