using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionsController : MonoBehaviour
{
	public float speed;

	private Animator animator;
	private Rigidbody2D rigidbody;

	protected virtual void Start ()
	{
		animator = GetComponent<Animator> ();
		rigidbody = GetComponent<Rigidbody2D> ();
	}

	protected void ManageAttack (bool action)
	{
		animator.SetBool ("attack", action);
	}

	protected void ManageMovement (float horizontal, float vertical)
	{
		if (horizontal != 0f || vertical != 0f) {
			animator.SetBool ("moving", true);
			AnimateWalk(horizontal, vertical);
		} else {
			animator.SetBool ("moving", false);
		}

		Vector2 movement = new Vector2(horizontal, vertical);
		rigidbody.AddForce(movement * speed);
	}

	void AnimateWalk (float horizontal, float vertical)
	{
		if (vertical > 0 && vertical > horizontal) {
			animator.SetInteger ("direction", 1);
		}
		if (horizontal > 0 && vertical < horizontal) {
			animator.SetInteger ("direction", 2);
		}
		if (vertical < 0 && vertical < horizontal) {
			animator.SetInteger ("direction", 3);
		}
		if (horizontal < 0 && vertical > horizontal) {
			animator.SetInteger ("direction", 4);
		}
	}

	protected void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Exit") {
			GameController.instance.Restart();

			enabled = false;
		}
	}

}
