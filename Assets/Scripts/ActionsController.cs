using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class ActionsController : MonoBehaviour
{
	public float restartLevelDelay = 1f;

	public float speed;
	public int health;
	public int damage;

	private Animator animator;
	private Rigidbody2D rigidbody;

	protected virtual void Start ()
	{
		animator = GetComponent<Animator> ();
		rigidbody = GetComponent<Rigidbody2D> ();
	}

	protected void ManageAttack (bool action)
	{
		animator.SetBool("attack", action);
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

	protected void Damage (int loss)
	{
		animator.SetTrigger ("hit");

		health -= loss;

		CheckIfGameOver();
	}

	protected void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "exit") {
			Invoke("Restart", restartLevelDelay);

			enabled = false;
		}
	}

	void CheckIfGameOver ()
	{
		if (health <= 0)
		{
			GameController.instance.GameOver();
		}
	}

	private void Restart ()
	{
		SceneManager.LoadScene(0);
	}

}
