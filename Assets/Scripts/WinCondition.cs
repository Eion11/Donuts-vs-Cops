using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour {

	public int copKillVictoy = 3;
	public int copsKilled = 0;

	public int copDefeat = 3;
	public int copsPassed = 0;

	private GameObject winLoseText;

	// Use this for initialization
	void Start () {
		winLoseText = GameObject.Find ("VictoryLoseText");
		winLoseText.GetComponent<Text>().text = " ";
	}
	
	// Update is called once per frame
	void Update () {
		if (checkPlayerWin()) {
			winLoseText.GetComponent<Text>().text = "VICTORY";
			winLoseText.GetComponent<Text> ().color = new Color (0, 255, 0);
			Time.timeScale = 0;
		}
		else if (checkPlayerLose()) {
			winLoseText.GetComponent<Text>().text = "DEFEAT";
			winLoseText.GetComponent<Text> ().color = new Color (255, 0, 0);

			Time.timeScale = 0;
		}
	}

	bool checkPlayerWin()
	{
		if (copsKilled >= copKillVictoy) {
			return true;
		}
		return false;
	}

	bool checkPlayerLose()
	{
		if (copsPassed >= copDefeat) {
			return true;
		}
		return false;
	}
}
