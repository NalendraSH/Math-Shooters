using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	private Text theText;
	private ScoreManager scoreManager;
	private SaveLoadManager saveLoad;
	private PlaneController planeController;
	public GameObject gameOver;

	private Slider healthBar;

	public int startHealth;
	public int currentHealth;

	//private int hitted;

	// Use this for initialization
	void Start () {
		healthBar = GetComponent<Slider> ();

		//theText = GetComponent<Text> ();
		scoreManager = FindObjectOfType<ScoreManager> ();
		saveLoad = FindObjectOfType<SaveLoadManager> ();
		planeController = FindObjectOfType<PlaneController> ();

		currentHealth = startHealth;
		//currentHealth = PlayerPrefs.GetInt("PlayerCurrentHealth");
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth < 0) {
			//scoreManager.ResetScore ();
			currentHealth = 0;
		}

		//theText.text = "Health:         " + currentHealth;
		//hitted = PlayerPrefs.GetInt("WrongResultHitted");
		//currentHealth -= hitted;
		//hitted = 0;

		healthBar.value = currentHealth;

		saveLoad.loadGame ();

		if (currentHealth <= 0) {
			if (scoreManager.currentScore > saveLoad.score) {
				saveLoad.saveGame ();
			}

			dead ();
		}
	}

	private void dead(){
		scoreManager.currentScore = 0;
		Time.timeScale = 0f;
		gameOver.SetActive (true);
	}

	public void reset(){
		currentHealth = startHealth;
	}
}
