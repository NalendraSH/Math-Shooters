using UnityEngine;
using System.Collections;

public class LaserShootControl : MonoBehaviour {

	public float shootSpeed;

	public float timeToDestroy;
	public float destroyObjectOverTime;

	private Rigidbody2D myRigidBody2D;

	public GameObject hitEffect;

	// Use this for initialization
	void Start () {
		myRigidBody2D = GetComponent<Rigidbody2D> ();

		destroyObjectOverTime = timeToDestroy;
	}

	// Update is called once per frame
	void Update () {
		destroyObjectOverTime -= Time.deltaTime;

		myRigidBody2D.velocity = new Vector2 (myRigidBody2D.velocity.x, shootSpeed);

		if (destroyObjectOverTime < 0 || Time.timeScale == 0f) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Result") {
			Instantiate (hitEffect, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}

	public void destroy(){
		destroyObjectOverTime = -1;
	}
}
