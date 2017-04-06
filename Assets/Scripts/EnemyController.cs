using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : ActionsController {

	private Transform player;

	protected override void Start () {
		GameController.instance.AddEnemyToList(this);
		player = GameObject.FindGameObjectWithTag("Player").transform;

		base.Start();
	}

	public void MoveEnemy ()
	{
		int moveHorizontal = 0;
		int moveVertical = 0;

		if (Mathf.Abs (player.position.x - transform.position.x) < 1) {
			moveVertical = player.position.y > transform.position.y ? 1 : -1;
		} else {
			moveHorizontal = player.position.x > transform.position.x ? 1 : -1;
		}

		ManageMovement(moveHorizontal, moveVertical);
	}
}
