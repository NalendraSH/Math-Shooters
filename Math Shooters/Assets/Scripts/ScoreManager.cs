using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private Text scoreText;
	private LevelManager levelManager;

	public GameObject qBackground;

	public int currentScore;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
		scoreText = GetComponent<Text> ();
		currentScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//scoreText.text = "Score :   " + currentScore;

		string strScore = currentScore.ToString();
		switch (strScore.Length) {
		case 2:
			scoreText.text = "00000000" + currentScore;
			break;
		case 3:
			scoreText.text = "0000000" + currentScore;
			break;
		case 4:
			scoreText.text = "000000" + currentScore;
			break;
		case 5:
			scoreText.text = "00000" + currentScore;
			break;
		default:
			scoreText.text = "0000000000";
			break;
		}

		if (currentScore < 250) {
			levelManager.ScoreUnder250 ();
		}

		if (currentScore >= 250) {
			levelManager.ScoreOver250 ();
		}

		if (currentScore >= 500) {
			qBackground.transform.localScale = new Vector3 (1.2f, 1, 1);
			levelManager.ScoreOver500 ();
		}

		if (currentScore >= 600) {
			//qBackground.transform.localScale = new Vector3 (1.2f, 1, 1);
			levelManager.ScoreOver600 ();
		}
	}

	public void AddScore(int scorePoint){
		currentScore += scorePoint;
	}

	public void ResetScore(){
		currentScore = 0;
	}
}