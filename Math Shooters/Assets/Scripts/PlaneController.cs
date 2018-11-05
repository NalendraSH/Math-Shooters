using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {

	public float moveSpeed;
	private float moveVelocity;

	public Transform rightDividers;
	public Transform leftDividers;

	private Rigidbody2D myrigidbody2D;
	public GameObject fireIndicator;
	public Transform whereAmmoOutR;
	public Transform whereAmmoOutL;
	public Transform laserAmmo;
	public AudioSource laserAudio;

	private float timeDelayToShot;
	public float startingDelayShoot;
	private int fireIndicatorDelay;

	public AudioSource backsound;
	// Use this for initialization
	void Start () {
		myrigidbody2D = GetComponent<Rigidbody2D> ();

		timeDelayToShot = startingDelayShoot;

		fireIndicatorDelay = 0;

		fireIndicator.SetActive (false);

		Time.timeScale = 1f;

		backsound.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (fireIndicatorDelay >= 2) {
			fireIndicator.SetActive (false);
			fireIndicatorDelay = 0;
		}

		timeDelayToShot -= Time.deltaTime;

		#if UNITY_STANDALONE

		if (Input.GetKey(KeyCode.A) && Time.timeScale != 0f) {
			myrigidbody2D.transform.position = new Vector2 (myrigidbody2D.transform.position.x - moveSpeed, myrigidbody2D.transform.position.y);

			//myrigidbody2D.velocity = new Vector2 (-moveSpeed, myrigidbody2D.velocity.y);
		}

		if (Input.GetKey(KeyCode.D) && Time.timeScale != 0f) {
			myrigidbody2D.transform.position = new Vector2 (myrigidbody2D.transform.position.x + moveSpeed, myrigidbody2D.transform.position.y);

			//myrigidbody2D.velocity = new Vector2 (-moveSpeed, myrigidbody2D.velocity.y);
		}

		#endif

		if (myrigidbody2D.transform.position.x >= rightDividers.position.x) {
			myrigidbody2D.transform.position = new Vector2 (rightDividers.position.x, myrigidbody2D.transform.position.y);
		}

		if (myrigidbody2D.transform.position.x <= leftDividers.position.x) {
			myrigidbody2D.transform.position = new Vector2 (leftDividers.position.x, myrigidbody2D.transform.position.y);
		}

		#if UNITY_STANDALONE

		if (Input.GetKey (KeyCode.Return)) {
			//fireIndicator.SetActive (true);
			if (timeDelayToShot <= 0) {
				fireIndicator.SetActive (true);
				fireIndicatorDelay++;
				laserAudio.Play ();
				Instantiate (laserAmmo, whereAmmoOutR.position, laserAmmo.rotation);
				Instantiate (laserAmmo, whereAmmoOutL.position, laserAmmo.rotation);
				timeDelayToShot = startingDelayShoot;
			}

		}
		if (Input.GetKeyUp (KeyCode.Return)) {
			fireIndicator.SetActive (false);
		}

		#endif

		/*if (fireIndicatorDelay >= 4) {
			fireIndicator.SetActive (true);
			fireIndicatorDelay = 0;
		}*/
	}

	public void moveLeft(){
		//myrigidbody2D.transform.position = new Vector2 (myrigidbody2D.transform.position.x - moveSpeed, myrigidbody2D.transform.position.y);
		myrigidbody2D.velocity = new Vector2 (-moveSpeed*30, myrigidbody2D.velocity.y);
	}

	public void moveRight(){
		//myrigidbody2D.transform.position = new Vector2 (myrigidbody2D.transform.position.x + moveSpeed, myrigidbody2D.transform.position.y);
		myrigidbody2D.velocity = new Vector2 (moveSpeed*30, myrigidbody2D.velocity.y);
	}

	public void stopMove(){
		myrigidbody2D.velocity = new Vector2 (0, myrigidbody2D.velocity.y);
	}

	public void shoot(){
		fireIndicator.SetActive (true);
		laserAudio.Play ();
		Instantiate (laserAmmo, whereAmmoOutR.position, laserAmmo.rotation);
		Instantiate (laserAmmo, whereAmmoOutL.position, laserAmmo.rotation);
	}

	public void shootRelease(){
		fireIndicator.SetActive (false);
	}

	public void reset(){
		myrigidbody2D.transform.position = new Vector2 (0f, -3.5f);
	}
}
