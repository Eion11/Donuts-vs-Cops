using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Death : MonoBehaviour
{
	private double deathAtHealth = 0;	// what health the thing will die at
	private GameObject playerCurrency; 	// used to add currency to the player on death
	private GameObject winCondition;    // used to update the win condition

	void Start()
	{
		playerCurrency = GameObject.FindWithTag("PlayerCurrency");
		winCondition = GameObject.Find("WinCondition");

		// constantly check that the object is dead
		InvokeRepeating("checkIfDead", 0, 0.1f);
	}

	void Update()
	{
		
	}

	private void checkIfDead()
	{
		if (isDead())
		{
			removeObject();			
		}
	}





	//------------------------
	//---- Little Methods ----
	//------------------------

	private bool isDead()
	{
		if (GetComponent<Health>().currentHealth <= deathAtHealth)
		{
			return true;
		}

		return false;
	}

	private void removeObject()
	{
		if (this.tag.Equals("Donut"))
		{
			removeDonut();
		}
		else if (this.tag.Equals("Cop"))
		{
			destroyCop();
		}
		
		Destroy(gameObject);
	}

	private void removeDonut()
	{
		// tell the tile the donut was placed on is empty so that another donut can be placed here again
		string tileName = GetComponent<DonutTilePlacement>().getTileNameString();

		GameObject tile = GameObject.Find(tileName);
		tile.GetComponent<TileProperties>().donutOnTile = false;
	}

	private void destroyCop()
	{
		// increase the win condition by 1 so the game knows when the game will be won
		winCondition.GetComponent<WinCondition>().copsKilled += 1;
	}
}
