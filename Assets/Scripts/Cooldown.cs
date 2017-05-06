using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour {

	public bool onCooldown;
	public float timeStamp;
	public float cooldownTime = 5;

	// Use this for initialization
	void Start () {
		onCooldown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeStamp <= Time.time) {
			onCooldown = false;
			GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		}
	}

	public void startCooldown()
	{

		onCooldown = true;

		timeStamp = Time.time + cooldownTime;
		GetComponent<Image> ().color = new Color32 (50, 50, 50, 255);
	}
}
