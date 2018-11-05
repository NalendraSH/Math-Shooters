using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultControl : MonoBehaviour {

	private RandomQuestion randomQ;
	private LevelManager levelManager;
	private Text theText;

	private Rigidbody2D myRigidBody2D;
	public float textMoveSpeed;
	public int rotationSpeed;
	public AudioSource resultAudio;
	public AudioSource resultExplodedAudio;

	public GameObject resultPoint;
	//public bool resetQ;

	public int healthMax;
	private int currentHealth;

	// Use this for initialization
	public void Start () {
		randomQ = FindObjectOfType<RandomQuestion> ();
		levelManager = FindObjectOfType<LevelManager>();
		theText = GetComponent<Text> ();

		//resultPoint = FindObjectOfType<ResulPointPosition> ();

		myRigidBody2D = GetComponent<Rigidbody2D> ();

		randomQ.resultIsDestroyed = false;

		currentHealth = healthMax;

		transform.position = resultPoint.transform.position;

		//resetQ = false;

		if (resultPoint.transform.position.x < 0f) {
			textMoveSpeed = -textMoveSpeed;
			rotationSpeed = -rotationSpeed;
		}

	}
	
	// Update is called once per frame
	void Update () {
		//Destroy (hitEffect.gameObject);

		theText.text = "" + levelManager.result;

		myRigidBody2D.velocity = new Vector2 (-textMoveSpeed, -0.2f);
		myRigidBody2D.angularVelocity = rotationSpeed;

		if (currentHealth <= 0) {
			resultExplodedAudio.Play ();
			randomQ.resultIsDestroyed = true;
			randomQ.isKilled = true;
		}

		/*if (transform.localPosition.x < -315f || transform.localPosition.x > 315 || transform.localPosition.y < -125 || transform.localPosition.y > 125) {
			resetQ = true;
		}*/
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "ShootProjectiles") {
			currentHealth -= 1;
			resultAudio.Play ();
			//Destroy (other.gameObject);
		}
	}

}
