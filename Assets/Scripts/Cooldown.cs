using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
	public bool onCooldown;
	public float timeStamp;
	public float cooldownTime = 10;

	// Use this for initialization
	void Start()
	{
		onCooldown = false;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (timeStamp <= Time.time)
		{
			onCooldown = false;

		}
	}

	public void startCooldown()
	{

		onCooldown = true;

		timeStamp = Time.time + cooldownTime;

	}
}
