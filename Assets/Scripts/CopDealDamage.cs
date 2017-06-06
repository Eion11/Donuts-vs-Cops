﻿
using UnityEngine;

public class CopDealDamage : MonoBehaviour
{
	public double damageAmount = 0;		// the amount of damage the cop will do - set this in the inspector
	private Collider donutInFrontOfCop; // the donut that will be in front of the cop (null if there is no donut)

	void Start()
	{
		InvokeRepeating("dealDamageToDonut", 0.5f, 0.5f);	// repeadetly call this method every x seconds
	}

	void Update()
	{

	}

	void OnTriggerEnter(Collider collider)
	{
		if (isColliderADonut(collider))
		{
			donutInFrontOfCop = collider;
			setCopMovement(CopMoveState.STOPPED);
		}
	}

	private void dealDamageToDonut()
	{
		if (isDonutInFrontOfCop())
		{
			damageDonut();
		}
	}


	//------------------------
	//---- Little Methods ----
	//------------------------

	private void damageDonut()
	{
		donutInFrontOfCop.gameObject.GetComponent<Health>().takeDamage(damageAmount);
	}

	private bool isColliderADonut(Collider obj)
	{
		if (obj.gameObject.tag == "Donut")
		{
			return true;
		}

		return false;
	}

	private bool isDonutInFrontOfCop()
	{
		if (donutInFrontOfCop != null) // if donutInFrontOfCop is not null, that means there is a donut in front of the cop
		{
			return true;
		}

		return false;
	}

	private void setCopMovement(CopMoveState moveState)
	{
		if (moveState == CopMoveState.MOVING)
		{
			GetComponent<Movement>().setMoveSpeedToDefault();
		}
		else if (moveState == CopMoveState.STOPPED)
		{
			GetComponent<Movement>().setMoveSpeedStopped();
		}
	}

	private enum CopMoveState
	{
		MOVING, STOPPED
	}
}
