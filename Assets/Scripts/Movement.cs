using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float xMoveSpeedDefault;             // the movement speed that the object starts with
	public float xMax;                          // the x value that the object will die if it goes past
	public MovementDirection movementDirection; // so the script knows if the object is moving left or right

	private float xMoveSpeed;                   // the move speed of the object
	private GameObject winCondition;            // used to update victory condition (when cops reach deathX, defeat+1)
	private GameObject manager;
	void Start()
	{
		xMoveSpeedDefault /= 1000;
		setMoveSpeedToDefault();
		winCondition = GameObject.Find("WinCondition");

		InvokeRepeating("checkIfMaxXReached", 0, 0.1f);

		manager = GameObject.Find("UIManager");
	}

	void Update()
	{
		if (!(manager.GetComponent<UIManager>().getPausedState()))
		{
			updatePosition ();
		}
	}

	private void updatePosition()
	{
		if (movementDirection == MovementDirection.MOVING_RIGHT)
		{
			moveObjectRight();
		}
		else if (movementDirection == MovementDirection.MOVING_LEFT)
		{
			moveObjectLeft();
		}
	}

	private void checkIfMaxXReached()
	{
		if (movementDirection == MovementDirection.MOVING_RIGHT)
		{
			if (transform.position.x > xMax)
			{
				cancelObjectMoving();
			}
		}
		else if (movementDirection == MovementDirection.MOVING_LEFT)
		{
			if (transform.position.x < xMax)
			{
				cancelObjectMoving();
			}
		}
	}

	public void slowMovementSpeedTemporarily(float percentage, float seconds)
	{
		if (xMoveSpeed != 0)
		{
			xMoveSpeed = xMoveSpeedDefault * (percentage / 100);
			Debug.Log("Slow Temp... " + xMoveSpeed);

			CancelInvoke();
			Invoke("setMoveSpeedToDefault", seconds);
		}
	}





	//------------------------
	//---- Little Methods ----
	//------------------------

	public void setMoveSpeedToDefault()
	{
		xMoveSpeed = xMoveSpeedDefault;
	}

	public void setMoveSpeedStopped()
	{
		xMoveSpeed = 0;
	}


	private void moveObjectRight()
	{
		float x = transform.position.x + xMoveSpeed;
		float y = transform.position.y;
		float z = transform.position.z;

		transform.position = new Vector3(x, y, z);
	}

	private void moveObjectLeft()
	{
		float x = transform.position.x - xMoveSpeed;
		float y = transform.position.y;
		float z = transform.position.z;

		transform.position = new Vector3(x, y, z);
	}

	private void cancelObjectMoving()
	{
		if (gameObject.tag == "Cop")
		{
			// make the cop stop moving so it sits at the end
			setMoveSpeedStopped();

			// update the win conditions
			winCondition.GetComponent<WinCondition>().copsPassed += 1;
			winCondition.GetComponent<WinCondition>().copsKilled += 1;

			CancelInvoke();
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public enum MovementDirection
	{
		MOVING_LEFT, MOVING_RIGHT, STOPPED
	}
}
