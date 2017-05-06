using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDonutAvailable : MonoBehaviour {

	public bool donutAvialable = false;
	GameObject donutCost;
	GameObject playerCurrency;

	// Use this for initialization
	void Start ()
	{
		donutCost = GameObject.FindWithTag ("SprinklerCost");
		playerCurrency = GameObject.FindWithTag ("PlayerCurrency");
	}
	
	// Update is called once per frame
	void Update ()
	{
		donutAvialable = false;

		if (checkPlayerHasEnoughMoney () && checkDonutOnCooldown())
		{
			donutAvialable = true;
		}
	}

	bool checkPlayerHasEnoughMoney()
	{
		if (donutCost.GetComponent<DonutCost> ().donutCost <= playerCurrency.GetComponent<CurrencyValue> ().currency)
		{
			return true;
		}

		return false;
	}

	bool checkDonutOnCooldown()
	{
		if (GetComponent<Cooldown>().onCooldown)
		{
			return false;
		}

		return true;
	}
}
