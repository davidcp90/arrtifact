using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class GameController : MonoBehaviour
{
	public float startDelay = 2f;
	public static GameController instance = null;

	private Text levelText;
	private GameObject levelImage;
	private List<EnemyController> enemies;
	private bool doingSetup = true;

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

		doingSetup = true;

		levelImage = GameObject.Find("LevelImage");
		levelText = GameObject.Find("LevelText").GetComponent<Text> ();
		levelImage.SetActive(true);
		Invoke("HideLevelImage", startDelay);
	}

	void Update ()
	{
		if (!doingSetup)
		{
			for (int i = 0; i < enemies.Count; i++)
			{
				enemies[i].MoveEnemy ();
			}
		}
	}

	private void HideLevelImage ()
	{
		levelImage.SetActive(false);
		doingSetup = false;
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
		levelText.text = "Game Over";
		levelImage.SetActive(true);

		enabled = false;
	}
}
