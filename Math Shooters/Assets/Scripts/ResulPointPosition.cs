using UnityEngine;
using System.Collections;

public class ResulPointPosition : MonoBehaviour {

	// Use this for initialization
	public void Start () {
		transform.position = new Vector3 (Random.Range (-6, 6), transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
