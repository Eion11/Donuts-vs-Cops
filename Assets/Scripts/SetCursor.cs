using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCursor : MonoBehaviour
{
	private GameObject donut;
	public string selectedDonutName;
	public bool cursorChanged = false;

	private Texture2D cursorTexture;
	private Vector2 hotSpot = Vector2.zero;
	private CursorMode cursorMode = CursorMode.Auto;

	// Use this for initialization
	void Start()
	{
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
			cursorChanged = true;
			
			selectedDonutName = transform.parent.name;
		}
	}



	//------------------------
	//---- Little Methods ----
	//------------------------
	
	public void setCursorToDefault()
	{
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		cursorChanged = false;
	}
}
