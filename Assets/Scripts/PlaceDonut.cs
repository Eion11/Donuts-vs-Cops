using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceDonut : MonoBehaviour {
	GameObject donut;
	GameObject donutCost;
	GameObject playerCurrency;

	public Texture2D cursorTexture;
	private Vector2 hotSpot = Vector2.zero;
	private CursorMode cursorMode = CursorMode.Auto;
	public bool cursorChanged = false;

	// Use this for initialization
	void Start () {
		donut = GameObject.FindWithTag ("SprinklerDonut");
		donutCost = GameObject.FindWithTag ("SprinklerCost");

		cursorTexture = donut.GetComponent<Image> ().sprite.texture;
	}
	
	// Update is called once per frame
	void Update () {
			
	}
		
	public void OnClick()
	{
		if (donut.GetComponent<CheckDonutAvailable> ().donutAvialable) {
			Cursor.SetCursor (cursorTexture, hotSpot, cursorMode);
			cursorChanged = true;
		}
	}
}
