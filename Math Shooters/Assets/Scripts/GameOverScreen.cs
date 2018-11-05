using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	private HealthManager healthManager;
	private PlaneController planeController;
	private LaserShootControl laserController;

	public string quit;
	public AudioSource selectSound;

	// Use this for initialization
	void Start () {
		healthManager = FindObjectOfType<HealthManager> ();
		planeController = FindObjectOfType<PlaneController> ();
		laserController = FindObjectOfType<LaserShootControl> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Retry(){
		selectSound.Play ();
		Time.timeScale = 1f;
		healthManager.reset ();
		planeController.reset ();
		this.gameObject.SetActive (false);
	}

	public void quitToMainMenu(){
		selectSound.Play ();
		//Time.timeScale = 1f;
		Application.LoadLevel (quit);
	}
}
