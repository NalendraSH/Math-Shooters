using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string gameScene;

	public GameObject about;

	public AudioSource selectSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playGame(){
		selectSound.Play ();
		Application.LoadLevel (gameScene);
	}

	public void aboutDeveloper(){
		selectSound.Play ();
		about.SetActive (true);
	}

	public void exitGame(){
		selectSound.Play ();
		Application.Quit ();
	}

	public void closeAbout(){
		selectSound.Play ();
		about.SetActive (false);
	}
}
