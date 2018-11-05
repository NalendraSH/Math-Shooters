using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverHighScore : MonoBehaviour {

	private Text theText;
	private SaveLoadManager saveLoad;
	private ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
		theText = GetComponent<Text> ();
		saveLoad = FindObjectOfType<SaveLoadManager> ();
		scoreManager = FindObjectOfType<ScoreManager> ();
	
		saveLoad.loadGame ();
		theText.text = "Highscore: " + saveLoad.score;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
