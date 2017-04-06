using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public static GameController instance = null;
	private List<EnemyController> enemies;

	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		} else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);

		enemies = new List<EnemyController> ();
	}

	void Update ()
	{
		for (int i = 0; i < enemies.Count; i++)
		{
			enemies[i].MoveEnemy ();
		}
	}

	public void AddEnemyToList (EnemyController script)
	{
		enemies.Add(script);
	}

	public void Restart ()
	{
		SceneManager.LoadScene(0);
	}

	public void GameOver ()
	{
		enabled = false;
	}
}
