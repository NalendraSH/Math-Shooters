using UnityEngine;
using System.Collections;

public class DestroyFinisedParticle : MonoBehaviour {
	
	public float particleTime;
	private float currentParticleTime;

	// Use this for initialization
	void Start () {

		currentParticleTime = particleTime;
	}
	
	// Update is called once per frame
	void Update () {
		currentParticleTime -= Time.deltaTime;

		if (currentParticleTime < 0) {
			Destroy (gameObject);
		}
	}
}
