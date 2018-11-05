using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RandomQuestion : MonoBehaviour {

	//private Text randomQText;
	//private int a,b;
	//public int result;

	public GameObject theResultControl;
	//public Transform resultPoint;
	private ResulPointPosition resultPoint;
	private ResultControl resultControl;
	private LevelManager levelManager;
	//private OptionManager optManager;

	private float delay;
	public float startDelay;

	private float resultOptionDelay;
	public float resultOptionStartDelay;

	public bool resultIsDestroyed;

	public int score;
	private ScoreManager scoreMan;
	public bool isKilled;

	//public GameObject resultClone;
	public GameObject[] resultClone;
	public int resulCloneIndex;

	// Use this for initialization
	void Start () {
		//randomQText = GetComponent<Text> ();
		resultPoint = FindObjectOfType<ResulPointPosition> ();
		resultControl = FindObjectOfType<ResultControl> ();
		scoreMan = FindObjectOfType<ScoreManager> ();
		levelManager = FindObjectOfType<LevelManager> ();
		//optManager = FindObjectOfType<OptionManager> ();

		//a = Random.Range (1, 20);
		//b = Random.Range (1, 20);
		//result = a + b;

		//theResultControl.transform.position = resultPoint.transform.position;

		delay = startDelay;

		if (!resultIsDestroyed) {
			resultOptionDelay = resultOptionStartDelay;
		}

		//Instantiate (resultClone);

		//Instantiate (theResultControl/*, transform.position, theResultControl.transform.rotation*/);
	}
	
	// Update is called once per frame
	void Update () {
		//Random.Range (1, 100);
		//randomQText.text = a + " + " + b + " = ?";

		delay -= Time.deltaTime;
		resultOptionDelay -= Time.deltaTime;

		if (resulCloneIndex >= 6) {
			resulCloneIndex = 0;
			/*for (int i = 0; i < resultClone.Length; i++) {
				resultClone [i].SetActive (false);
			}*/
			//optManager.Start ();
		}

		if (resultOptionDelay == delay) {
			resultOptionDelay++;
		}

		if (resultOptionDelay < 0) {
			resultPoint.Start ();
			resultClone [resulCloneIndex].SetActive (true);
			//Instantiate (resultClone);
			resultOptionDelay = resultOptionStartDelay;
			resulCloneIndex++;
		}

		if (delay < 0 /*|| resultControl.resetQ == true*/ || resultIsDestroyed) {
			//Instantiate (resultClone);
			//resulCloneIndex = 0;
			if (isKilled) {
				scoreMan.AddScore (score);
				isKilled = !isKilled;
			}
			resultPoint.Start ();
			levelManager.Start ();
			StartCoroutine ("Start");
			resultControl.Start ();
		}
	}
}
