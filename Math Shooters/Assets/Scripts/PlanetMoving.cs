using UnityEngine;
using System.Collections;

public class PlanetMoving : MonoBehaviour {

	private PlanetControl planetControl;

	public GameObject[] planet;
	public int planetIndex;

	// Use this for initialization
	void Start () {
		planetControl = FindObjectOfType<PlanetControl> ();

		planetIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (planetIndex > 5) {
			planetIndex = 0;
		}

		planet [planetIndex].SetActive (true);

	}
}
