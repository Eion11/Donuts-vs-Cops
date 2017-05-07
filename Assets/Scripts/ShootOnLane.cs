using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOnLane : MonoBehaviour
{
	public bool copActive = false;
	private Collider copInLane;

	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
		// This means the cop has been destroyed, and no longer in the lane
		if (copActive == true && copInLane == null)
		{
			copActive = false;
		}
	}

	void OnTriggerStay(Collider cop)
	{
		if (cop.gameObject.tag == "Cop")
		{
			copActive = true;
			copInLane = cop;
		}
	}
}
