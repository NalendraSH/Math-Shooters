using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour {

	public GameObject resultPoint;
	private ResulPointPosition resultPointMan;
	private Rigidbody2D myRigidBody2D;
	private HealthManager healthManager;

	public float optionSpeed;
	public int optionRotSpeed;
	public AudioSource resultHitAudio;

	private Text theText;
	private int randomR;

	private float delay;
	public float optionStartDelay;

	//private int hitted;
	private int health;
	public int optionStartHealth;

	public GameObject wrongIndicator;
	public float indicatorDelay;
	private float indicatorCurrentDelay;

	// Use this for initialization
	void Start () {
		//resultPoint = FindObjectOfType<ResulPointPosition> ();
		theText = GetComponent<Text> ();
		resultPointMan =  FindObjectOfType<ResulPointPosition>();
		healthManager = FindObjectOfType<HealthManager> ();
		randomR = Random.Range (1, 40);

		transform.position = resultPoint.transform.position;

		myRigidBody2D = GetComponent<Rigidbody2D> ();
	
		if (resultPoint.transform.position.x < 0f) {
			optionSpeed = -optionSpeed;
			optionRotSpeed = -optionRotSpeed;
		}

		delay = optionStartDelay;
		health = optionStartHealth;

		wrongIndicator.SetActive (false);
		indicatorCurrentDelay = indicatorDelay;

		//hitted = 0;
	}
	
	// Update is called once per frame
	void Update () {
		delay -= Time.deltaTime;

		theText.text = "" + randomR;

		myRigidBody2D.velocity = new Vector2 (-optionSpeed, -0.2f);
		myRigidBody2D.angularVelocity = optionRotSpeed;

		if (delay <= 0) {
			resultPointMan.Start ();
			StartCoroutine ("Start");
		}
	
		if (health <= 0) {
			//healthManager.currentHealth--;
			resultPointMan.Start ();
			StartCoroutine ("Start");
			health = optionStartHealth;
		}

		//if (wrongIndicator.activeInHierarchy) {
			indicatorCurrentDelay -= Time.deltaTime;
		//}

		if (indicatorCurrentDelay <= 0) {
			wrongIndicator.SetActive (false);
			indicatorCurrentDelay = indicatorDelay;
		}

		//healthManager.currentHealth = playerHealth;
		//PlayerPrefs.SetInt ("WrongResultHitted", hitted);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "ShootProjectiles") {
			health--;
			healthManager.currentHealth--;
			wrongIndicator.SetActive (true);
			resultHitAudio.Play ();
		}
	}
}
