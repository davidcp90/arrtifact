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
		float moveHorizontal;
		float moveVertical;

		moveVertical = player.position.y - transform.position.y;
		moveHorizontal = player.position.x - transform.position.x;

		if (Mathf.Abs (player.position.x - transform.position.x) < 1.5 && Mathf.Abs (player.position.y - transform.position.y) < 1.5) {
			ManageAttack (true);
		} else {
			ManageAttack (false);
		}

		ManageMovement(moveHorizontal, moveVertical);
	}
}
