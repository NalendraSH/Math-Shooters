using UnityEngine;
using System.Collections;

public class PlanetControl : MonoBehaviour {

	private Rigidbody2D myRigidBody2D;
	private PlanetMoving planetMove;

	public float planetMoveSpeed;
	public int planetRotationSpeed;


	// Use this for initialization
	public void Start () {
		myRigidBody2D = GetComponent<Rigidbody2D> ();
		planetMove = FindObjectOfType<PlanetMoving> ();
	}
	
	// Update is called once per frame
	void Update () {
		myRigidBody2D.velocity = new Vector2 (myRigidBody2D.velocity.x, planetMoveSpeed);
		myRigidBody2D.angularVelocity = planetRotationSpeed;

		if (transform.localPosition.y <= -550) {
			transform.localPosition = new Vector2 (transform.localPosition.x, 550f);
			gameObject.SetActive (false);
			planetMove.planetIndex++;
		}

		if (planetMove.planetIndex == 2 || planetMove.planetIndex == 3 || planetMove.planetIndex == 5) {
			planetMoveSpeed = -1;
			planetRotationSpeed = 15;
		}
	}
}
