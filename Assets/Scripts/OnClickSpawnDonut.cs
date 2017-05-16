using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickSpawnDonut : MonoBehaviour
{
	public GameObject donutPrefab;   // the prefab that will be used to instansiate from
	private GameObject donutClone;           // the donut that the prefab will be instansiated into
	private GameObject cursor;
	private GameObject playerCurrency;

	void Start()
	{
		cursor = GameObject.Find("Cursor Set On Click");
		playerCurrency = GameObject.FindWithTag("PlayerCurrency");
	}

	void Update()
	{

	}

	private void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (canPlaceATower())
			{
				PlaceTower();

				playerCurrency.GetComponent<PlayerCurrency>().spendCurrency(getDonutCost());

				cursor.GetComponent<SetCursor>().setCursorToDefault();

				GetComponent<TileProperties>().donutOnTile = true;
			}
		}
	}

	private void PlaceTower()
	{
		// Create the donut
		donutClone = Instantiate(donutPrefab, transform.position, Quaternion.identity) as GameObject;

		// Set some propities of the donut so it knows its name and place
		donutClone.GetComponent<DonutTilePlacement>().setTileString(this.transform.name);
		donutClone.GetComponent<ProduceProjectile>().lane = GetComponent<TileProperties>().lane;

		putDonutOnCooldown();
	}




	//------------------------
	//---- Little Methods ----
	//------------------------
	
	private bool canPlaceATower()
	{
		if (cursor.GetComponent<SetCursor>().cursorChanged && GetComponent<TileProperties>().donutOnTile == false)
		{
			return true;
		}

		return false;
	}

	private int getDonutCost()
	{
		return GameObject.Find(cursor.GetComponent<SetCursor>().selectedDonutName).GetComponent<CheckDonutAvailableForPurchase>().donutCost;
	}

	private void putDonutOnCooldown()
	{
		GameObject donut = GameObject.Find(cursor.GetComponent<SetCursor>().selectedDonutName);
		donut.GetComponent<DonutCooldown>().startDonutCooldown();
	}
}
