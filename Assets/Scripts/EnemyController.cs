using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : ActionsController {

	public int damage;

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

		moveVertical = (player.position.y - transform.position.y) >= 0 ? 1 : -1;
		moveHorizontal = (player.position.x - transform.position.x) >= 0 ? 1 : -1;

		if (Mathf.Abs (player.position.x - transform.position.x) < 1 && Mathf.Abs (player.position.y - transform.position.y) < 1) {
			ManageAttack (true);
			PlayerController hitPlayer = player.GetComponent<PlayerController> () as PlayerController;
			hitPlayer.Damage(damage);
		} else {
			ManageAttack (false);
		}

		ManageMovement(moveHorizontal, moveVertical);
	}
}
