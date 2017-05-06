using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OnClickSpawn : MonoBehaviour {

    public GameObject donutPrefab;
    GameObject donutClone;
	public bool isTileEmpty = true;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnMouseOver()
    {
        if ( Input.GetMouseButtonDown(0))
        {
			GameObject cursor = GameObject.Find ("Sprinkler On Click");
			GameObject donutCost = GameObject.FindWithTag ("SprinklerCost");
			GameObject playerCurrency = GameObject.FindWithTag ("PlayerCurrency");

			if (cursor.GetComponent<PlaceDonut>().cursorChanged && isTileEmpty) {
				Debug.Log ("Mouse Cursor is Donut!");
				PlaceTower ();

				Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
				cursor.GetComponent<PlaceDonut> ().cursorChanged = false;

				playerCurrency.GetComponent<CurrencyValue> ().spendCurrency (donutCost.GetComponent<DonutCost> ().donutCost);
				isTileEmpty = false;
			}
        }
    }

    private void PlaceTower()
    {
		donutClone = Instantiate (donutPrefab, transform.position, Quaternion.identity) as GameObject;
		donutClone.GetComponent<TileDonutPlacement>().setTileString (this.transform.name);
	
		GameObject donut = GameObject.FindWithTag ("SprinklerDonut");
		donut.GetComponent<Cooldown> ().startCooldown ();
    }
}
