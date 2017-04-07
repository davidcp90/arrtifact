using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox;

	public Text theText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;

	// Use this for initialization
	void Start () 
	{

		if (textFile != null)
		{
			textLines = (textFile.text.Split('\n'));

		}

		if(endAtLine == 0)
		{
			endAtLine = textLines.Length - 1;

		}

	}

	void Update()
	{

		theText.text = textLines [currentLine];

		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			currentLine += 1;
		}

	}

}