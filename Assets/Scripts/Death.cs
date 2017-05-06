using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	public double deathAtHealth = 0;
	private GameObject playerCurrency;

	// Use this for initialization
	void Start () {
		playerCurrency = GameObject.FindWithTag ("PlayerCurrency");
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Health>().currentHealth == deathAtHealth) {
			if (this.tag.Equals ("Donut")) {
				string tileName = GetComponent<TileDonutPlacement> ().getTileString ();

				GameObject tile = GameObject.Find (tileName);
				tile.GetComponent<OnClickSpawn> ().isTileEmpty = true;
			} else if (this.tag.Equals ("Cop")) {
				playerCurrency.GetComponent<CurrencyValue> ().gainCurrency (35);

			}
			Destroy (gameObject);
		}
	}

}
