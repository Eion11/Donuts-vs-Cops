using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCopInLane : MonoBehaviour
{
	public bool copActive = false;
	//private Collider copInLane;
	public int copsInLane = 0;

	void Start()
	{
		InvokeRepeating("isCopInLane", 0, 0.2f);
	}
	
	void Update()
	{
		
	}

	void OnTriggerEnter(Collider cop)
	{
		if (cop.gameObject.tag == "Cop")
		{
			Debug.Log("Cops in Lane: " + copsInLane);
			copsInLane++;
		}

			/*
			if (cop.gameObject.tag == "Cop")
			{
				copActive = true;
				copInLane = cop;
			}
			*/
		}




	//------------------------
	//---- Little Methods ----
	//------------------------

	private void isCopInLane()
	{


		/*
		if (copActive == true && copInLane == null)
		{
			copActive = false;
		}
		*/
	}
}
