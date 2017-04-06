using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ActionsController
{
	private void Update ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		bool action = Input.GetButton("Fire1");

		ManageMovement(moveHorizontal, moveVertical);
		ManageAttack(action);
	}

}
