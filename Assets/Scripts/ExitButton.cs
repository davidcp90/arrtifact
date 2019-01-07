using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour 
{
	public Canvas quitMenu;
	public Button exitText;

	void Start ()

	{
		quitMenu = quitMenu.GetComponent<Canvas>();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;

	}

	public void ExitPress()

	{
		quitMenu.enabled = true;
		exitText.enabled = false;

	}

	public void NoPress()

	{
		quitMenu.enabled = false; //we'll disable the quit menu, meaning it won't be visible anymore
		exitText.enabled = true;

	}

	public void ExitGame () //This function will be used on our "Yes" button in our Quit menu

	{
		Application.Quit(); //this will quit our game. Note this will only work after building the game

	}

}
