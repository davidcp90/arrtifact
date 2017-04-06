using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadController : MonoBehaviour
{
	public GameObject gameManager;

	void Awake ()
	{
		if (GameController.instance == null)
		{
			Instantiate(gameManager);
		}
	}

}
