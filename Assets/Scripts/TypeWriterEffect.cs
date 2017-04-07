using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TypeWriterEffect : MonoBehaviour {

	public float delay = 0.01f;
	public string fullText;
	private string currentText = "";

	// Use this for initialization
	void Start () {
		StartCoroutine(ShowText());
	}

	IEnumerator ShowText(){
		string textToShow = fullText.Replace ("//n", "\n");
		for (int i = 0; i <= textToShow.Length; i++){
			currentText = textToShow.Substring (0, i);
			this.GetComponent<Text> ().text = currentText;
			if (i == textToShow.Length) {
				SceneManager.LoadScene ("Start Menu 2");
			}
			yield return new WaitForSeconds (delay);

		}
	}
}
