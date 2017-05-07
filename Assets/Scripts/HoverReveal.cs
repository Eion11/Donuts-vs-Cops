using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverReveal : MonoBehaviour
{
	public bool mouseOver;
	public bool empty;

	// Use this for initialization
	void Start()
	{
		mouseOver = false;
	}
	
	// Update is called once per frame
	void Update()
	{
		empty = GetComponent<OnClickSpawn>().isTileEmpty;

		if (mouseOver && !empty)
		{
			GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.4f);
		}
		else if (mouseOver)
		{
			GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.25f);
		}
		else
		{
			GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.1f);
		}
	}

	private void OnMouseOver()
	{
		mouseOver = true;
	}

	private void OnMouseExit()
	{
		mouseOver = false;
	}
}
