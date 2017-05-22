﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class OnClickSpawnDonut : MonoBehaviour
{
	public Object donutPrefab;   // the prefab that will be used to instansiate from
	private GameObject donutClone;           // the donut that the prefab will be instansiated into
	private GameObject cursorManager;
	private GameObject playerCurrency;

	void Start()
	{
		cursorManager = GameObject.Find("Cursor Manager");
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

				cursorManager.GetComponent<CursorManager>().setCursorToDefault();

				GetComponent<TileProperties>().donutOnTile = true;
			}
		}
	}

	private void PlaceTower()
	{
		// Create the donut
		donutPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/" + cursorManager.GetComponent<CursorManager>().selectedDonutName + ".prefab", typeof(GameObject));
		donutClone = Instantiate(donutPrefab, transform.position, Quaternion.identity) as GameObject;

		// Set some propities of the donut so it knows its name and place
		donutClone.GetComponent<DonutTilePlacement>().setTileNameString(this.transform.name);
		donutClone.GetComponent<DonutTilePlacement>().lane = GetComponent<TileProperties>().lane;

		putDonutOnCooldown();
	}




	//------------------------
	//---- Little Methods ----
	//------------------------
	
	private bool canPlaceATower()
	{		
		if (cursorManager.GetComponent<CursorManager>().cursorChanged && GetComponent<TileProperties>().donutOnTile == false)
		{
			return true;
		}

		return false;
	}

	private int getDonutCost()
	{
		return GameObject.Find(cursorManager.GetComponent<CursorManager>().selectedDonutName).GetComponent<CheckDonutAvailableForPurchase>().donutCost;
	}

	private void putDonutOnCooldown()
	{
		GameObject donut = GameObject.Find(cursorManager.GetComponent<CursorManager>().selectedDonutName);
		donut.GetComponent<DonutCooldown>().startDonutCooldown();
	}
}
