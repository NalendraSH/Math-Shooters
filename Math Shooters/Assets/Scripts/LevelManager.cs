using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	//private ScoreManager scoreManager;
	//private RandomQuestion randomQ;
	private Text theText;

	private int a,b,c,d;
	public int result;

	// Use this for initialization
	public void Start () {
		//scoreManager = FindObjectOfType<ScoreManager> ();
		//randomQ = FindObjectOfType<RandomQuestion> ();
		theText = GetComponent<Text> ();

		a = Random.Range (1, 20);
		b = Random.Range (20, 40);
		c = Random.Range (10, 50);
		d = Random.Range (1, 10);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ScoreUnder250(){
		theText.text = a + " + " + b + " = ?";
		result = a + b;
	}

	public void ScoreOver250(){
		theText.text = a + " - " + b + " = ?";
		result = a - b;
	}

	public void ScoreOver500(){
		theText.text = a + " + " + b + " - " + c + " = ?";  
		result = a + b - c;
	}

	public void ScoreOver600(){
		theText.text = a + " x " + b + " + " + c + " = ?";
		result = a * b + c;
	}
}
