using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadManager : MonoBehaviour {

	private ScoreManager scoreManager;

	public int score;

	private string savePath;

	public void saveGame(){
		//savePath = Application.persistentDataPath + "/gameInfo.dat";
		scoreManager = FindObjectOfType<ScoreManager> ();

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/gameInfo.dat");

		GameData gameData = new GameData ();
		gameData.scoreData = scoreManager.currentScore;

		bf.Serialize (file, gameData);
		file.Close();
	}

	public void loadGame(){
		//savePath = Application.persistentDataPath + "/gameInfo.dat";
		if(File.Exists (Application.persistentDataPath + "/gameInfo.dat")){
			BinaryFormatter bf  = new BinaryFormatter ();
			FileStream file     = File.Open (Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);

			GameData gameData = (GameData) bf.Deserialize (file);
			file.Close ();

			score = gameData.scoreData;
		}
	}
}

[System.Serializable]
class GameData{
	public int scoreData;
}