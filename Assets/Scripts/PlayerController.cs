using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : ActionsController
{
	public int health;
	public Text healthText;

	protected override void Start ()
	{
		healthText.text = "Health: " + health;

		base.Start ();
	}

	private void Update ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		ManageMovement(moveHorizontal, moveVertical);
	}

	public void Damage (int loss)
	{
		health -= loss;

		healthText.text = "-" + loss + " Health: " + health;

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
