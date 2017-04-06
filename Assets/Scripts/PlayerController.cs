using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ActionsController
{
	public int health;

	private void Update ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		ManageMovement(moveHorizontal, moveVertical);
	}

	public void Damage (int loss)
	{
		health -= loss;

		CheckIfGameOver();
	}

	void CheckIfGameOver ()
	{
		if (health <= 0)
		{
			GameController.instance.GameOver();
		}
	}
}
