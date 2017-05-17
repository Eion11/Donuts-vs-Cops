using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCursor : MonoBehaviour
{
	private GameObject donut;
	private GameObject cursorManager;

	private Texture2D cursorTexture;
	private Vector2 hotSpot = Vector2.zero;
	private CursorMode cursorMode = CursorMode.Auto;

	// Use this for initialization
	void Start()
	{
		cursorManager = GameObject.Find("Cursor Manager");
		donut = transform.parent.gameObject;
		cursorTexture = GetComponentInParent<Image>().sprite.texture;
	}
	
	// Update is called once per frame
	void Update()
	{
			
	}

	public void OnClick()
	{
		if (donut.GetComponent<CheckDonutAvailableForPurchase>().donutAvialable)
		{
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);

			cursorManager.GetComponent<CursorManager>().cursorChanged = true;
			cursorManager.GetComponent<CursorManager>().selectedDonutName = transform.parent.name;
		}
	}	
}
