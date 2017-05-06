using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopDealDamage : MonoBehaviour {

	public double damageAmount = 0;
	Collider donutInFrontOf;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("dealDamageToDonut", 0.5f, 0.5f);

	}
	
	// Update is called once per frame
	void Update () {
		if (donutInFrontOf.GetComponent<Health>().currentHealth <= 0) 
		{
			GetComponent<Movement> ().xMoveSpeed = -0.015f;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Donut")
		{
			donutInFrontOf = other;
			GetComponent<Movement> ().xMoveSpeed = 0;
		}
	}


	void dealDamageToDonut()
	{
		donutInFrontOf.gameObject.GetComponent<Health> ().takeDamage (damageAmount);
	}
}
