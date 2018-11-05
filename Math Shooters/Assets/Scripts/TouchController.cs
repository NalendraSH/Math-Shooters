using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	private PlaneController planeController;

	public GameObject leftArrowPressedButton;
	public GameObject rightArrowPressedButton;
	public GameObject shootPressedButton;

	// Use this for initialization
	void Start () {
		planeController = FindObjectOfType<PlaneController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Shoot(){
		planeController.shoot();
		shootPressedButton.SetActive (true);
	}

	public void ShootRelease(){
		planeController.shootRelease ();
		shootPressedButton.SetActive (false);
	}

	public void LeftArrowPressed(){
		planeController.moveLeft ();
		leftArrowPressedButton.SetActive (true);
	}

	public void RightArrowPressed(){
		planeController.moveRight ();
		rightArrowPressedButton.SetActive (true);
	}

	public void OnRelease(){
		planeController.stopMove();
		leftArrowPressedButton.SetActive (false);
		rightArrowPressedButton.SetActive (false);
	}
}
